    private static string GetLocalTimeZoneId()
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(
                            @"SYSTEM\CurrentControlSet\Control\TimeZoneInformation");
        string value = (string)key.GetValue("TimeZoneKeyName");
        if (string.IsNullOrEmpty(value))
            value = (string)key.GetValue("StandardName");
        key.Close();
        return value;
    }
