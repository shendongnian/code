        string installkey = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
        string entryLabel = "your-app-name.exe";
        System.OperatingSystem osInfo = System.Environment.OSVersion;
        string version = osInfo.Version.Major.ToString() + '.' + osInfo.Version.Minor.ToString();
        uint editFlag = (uint)((version == "6.2") ? 0x2710 : 0x2328); // 6.2 = Windows 8 and therefore IE10
        RegistryKey existingSubKey = Registry.LocalMachine.OpenSubKey(installkey, false); // readonly key
        if (existingSubKey.GetValue(entryLabel) == null) {
            existingSubKey = Registry.LocalMachine.OpenSubKey(installkey, true); // writable key
            existingSubKey.SetValue(entryLabel, unchecked((int)editFlag), RegistryValueKind.DWord);
        }
