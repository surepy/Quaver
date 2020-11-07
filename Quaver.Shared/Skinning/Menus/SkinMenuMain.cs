﻿using IniFileParser.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Quaver.Shared.Config;

namespace Quaver.Shared.Skinning.Menus
{
    public class SkinMenuMain : SkinMenu
    {
        public Texture2D Background { get; private set; }

        public Texture2D NavigationButton { get; private set; }

        public Texture2D NavigationButtonSelected { get; private set; }

        public float? NoteVisualizerOpacity { get; private set; }

        public Color? AudioVisualizerColor { get; private set; }

        public float? AudioVisualizerOpacity { get; private set; }

        public Color? NavigationButtonTextColor { get; private set; }

        public Color? NavigationQuitButtonTextColor { get; private set; }

        public SkinMenuMain(SkinStore store, IniData config) : base(store, config)
        {
        }

        protected override void ReadConfig()
        {
            var ini = Config["MainMenu"];

            var noteVisualizerOpacity = ini["NoteVisualizerOpacity"];
            ReadIndividualConfig(noteVisualizerOpacity, () => NoteVisualizerOpacity = ConfigHelper.ReadFloat(0, noteVisualizerOpacity));

            var audioVisualizerColor = ini["AudioVisualizerColor"];
            ReadIndividualConfig(audioVisualizerColor, () => AudioVisualizerColor = ConfigHelper.ReadColor(Color.Transparent, audioVisualizerColor));

            var audioVisualizerOpacity = ini["AudioVisualizerOpacity"];
            ReadIndividualConfig(audioVisualizerOpacity, () => AudioVisualizerOpacity = ConfigHelper.ReadFloat(0, audioVisualizerOpacity));

            var navBtnTextColor = ini["NavigationButtonTextColor"];
            ReadIndividualConfig(navBtnTextColor, () => NavigationButtonTextColor = ConfigHelper.ReadColor(Color.Transparent, navBtnTextColor));

            var navQuitBtnTextColor = ini["NavigationQuitButtonTextColor"];
            ReadIndividualConfig(navQuitBtnTextColor, () => NavigationQuitButtonTextColor = ConfigHelper.ReadColor(Color.Transparent, navQuitBtnTextColor));
        }

        protected override void LoadElements()
        {
            const string folder = "MainMenu";

            Background = LoadSkinElement(folder, "menu-background.png");
            NavigationButton = LoadSkinElement(folder, "navigation-button.png");
            NavigationButtonSelected = LoadSkinElement(folder, "navigation-button-selected.png");
        }
    }
}