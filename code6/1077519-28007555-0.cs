    PrinterSettings CurrentSettings;
    // since we are storing the value in CurrentUser, WOW virtualization is not in effect
    // Marshal is certainly going to be in a processor specific module (mscorlib for Net4)
    string arch = typeof(Marshal).Assembly.GetName().ProcessorArchitecture.ToString();
    string myAppKeyName = @"Software\MyApplicationName" + arch;
    string printerSettingValueName = "PrinterSettings"
    // save
    using (var sk = Registry.CurrentUser.CreateSubKey(myAppKeyName))
    {
        sk.SetValue(printerSettingValueName, this.CurrentSettings.GetDevModeData(), RegistryValueKind.Binary);
    }
    // restore
    using (var sk = Registry.CurrentUser.CreateSubKey(myAppKeyName))
    {
        var data = sk.GetValue(printerSettingValueName, RegistryValueKind.Binary) as byte[];
        this.CurrentSettings = new PrinterSettings();
        if (data != null)
        {
            this.CurrentSettings.SetDevModeData(data);
        }
    }
