        Dim accent As MahApps.Metro.Accent = New MahApps.Metro.Accent("Green", New Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/Green.xaml", UriKind.RelativeOrAbsolute))
        Dim LightTheme As MahApps.Metro.AppTheme = New MahApps.Metro.AppTheme("BaseLight", New Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml", UriKind.RelativeOrAbsolute))
        Dim DarkTheme As MahApps.Metro.AppTheme = New MahApps.Metro.AppTheme("BaseDark", New Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseDark.xaml", UriKind.RelativeOrAbsolute))
        If Me.DarkThemeSelect_check.IsChecked = True Then
            ThemeManager.ChangeAppStyle(Application.Current, accent, DarkTheme)
        ElseIf Me.LightThemeSelect_check.IsChecked = True Then
            ThemeManager.ChangeAppStyle(Application.Current, accent, LightTheme)
        End If
