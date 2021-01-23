    Version windowsVistaVersion = new Version(6, 0, 0000, 0);
    if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version >= windowsVistaVersion)
    {
        App.Current.Resources.Source = new Uri("/PresentationFramework.AeroLite;component/themes/AeroLite.NormalColor.xaml", uriKind: UriKind.Relative);
    }
    else if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version < windowsVistaVersion)
    {
        App.Current.Resources.Source = new Uri("/PresentationFramework.Aero;component/themes/Aero.NormalColor.xaml", uriKind: UriKind.Relative);
    }
