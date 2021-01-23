    using wLog.Properties;
    var sName = frmControlProp[cn].SettingName;
 
    var type = Properties.Settings.Default.GetType();
    var pSettings = type.GetField(sName).GetValue(Properties.Settings.Default);
