    System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty("CustomSetting");
    
    
    Properties.Settings.Default["CustomSetting"] = txt_Cipher.Text;
    Properties.Settings.Default.Save();
    txt_Cipher.Text = string.Empty;
