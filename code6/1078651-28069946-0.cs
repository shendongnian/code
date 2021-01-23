    private void button2_Click(object sender, EventArgs e)
    {
      using (Configuration config1 = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None))
      {
        config1.AppSettings.Settings.Add("no_of_cameras", null);
        config1.AppSettings.Settings["no_of_cameras"].Value = (no.Value).ToString("G");
        config1.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
        Properties.Settings.Default.Reload();
       }
    }
