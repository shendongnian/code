        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog o1 = new OpenFileDialog();
            o1.Filter = "INI File |*.ini";
            if (o1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                INIFile ini = new INIFile(o1.FileName);
                string reini = ini.Read("Profile Settings", "User ID");
                textBox1.Text = reini;
                textBox3.Text = reini;
                textBox4.Text = reini;
                textBox5.Text = reini;
                string rechini = ini.Read("Startup", "Add To Startup");
                checkBox1.Checked = rechini == "checked";
           }
       }
