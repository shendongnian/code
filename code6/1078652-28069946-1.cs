    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      using (Configuration config2 = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None))
      {
        config2.AppSettings.Settings.Add("mail_enable", null);
        if (radioButton1.Checked == true)
        {
            label1.Show();
            textBox1.Show();
            config2.AppSettings.Settings["mail_enable"].Value = "true";
            config2.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        else
        {
            config2.AppSettings.Settings["mail_enable"].Value = "false";
            config2.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            textBox1.Hide();
            label1.Hide();
        }
        Properties.Settings.Default.Reload();
      }
    }
