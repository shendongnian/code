    private void Form_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingName != "")
            {
                TextBox1.text = Properties.Settings.Default.SettingName;
            }
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SettingName = //things you want to save;
        }
