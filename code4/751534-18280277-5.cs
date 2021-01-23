    public void SetTheme(string themeName) {
        ThemeManager.ApplicationThemeName = themeName;
        Properties.Settings.Default.ThemeName = themeName;
        Properties.Settings.Default.Save();
    }
