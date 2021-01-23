        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                MySettings.Default.WSites = "1";
                MySettings.Default.Save();
            }
            if (!checkBox7.Checked)
            {
                MySettings.Default.WSites = "";
                MySettings.Default.Save();
            }
        }
