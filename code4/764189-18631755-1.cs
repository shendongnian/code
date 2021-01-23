    //ensures no runtime errors if you try and view the setting before its created
    private bool _customSettingExists = false;
    public Form1()
    {
        InitializeComponent();
    }
    private void radButton1_Click(object sender, EventArgs e)
    {
        //You're saving your CustomSetting to properties, so you should read it from Default.Properties
        if (_customSettingExists)
            radTextBox1.Text = Properties.Settings.Default.Properties["CustomSetting"].ToString();
    }
    private void radButton2_Click(object sender, EventArgs e)
    {
        System.Configuration.SettingsProperty property = new
        System.Configuration.SettingsProperty("CustomSetting");
        property.SerializeAs = SettingsSerializeAs.Xml;
        property.DefaultValue = "Default";
        property.IsReadOnly = false;
        property.PropertyType = typeof(string);
        property.Provider =
        Properties.Settings.Default.Providers["LocalFileSettingsProvider"];
        property.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
        Properties.Settings.Default.Properties.Add(property);
        // Load settings now.
        Properties.Settings.Default.Reload();
        // Update the user itnerface.
        Properties.Settings.Default.Properties["CustomSetting"] = radTextBox1.Text;
        Properties.Settings.Default.Save();
        //now that you know a custom setting exists
        _customSettingExists = true;
    }
