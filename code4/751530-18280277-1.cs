    private void SetTheme(string themeName) {
        ThemeManager.ApplicationThemeName = themeName);
        Settings.Default.ThemeName = themeName;
        Settings.Default.Save();
    }
