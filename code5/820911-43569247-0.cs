    RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
    if (registry.GetValue("AutoConfigURL") != null)
    {
        registry.DeleteValue("AutoConfigURL");
    }
    registry.SetValue("ProxyEnable", 0, RegistryValueKind.DWord);
    registry.SetValue("ProxyServer", "");
    registry.SetValue("MigrateProxy", 0, RegistryValueKind.DWord);
    registry.SetValue("ProxyHttp1.1", 0, RegistryValueKind.DWord);
    registry.SetValue("ProxyOverride", "");
    registry.Flush();
