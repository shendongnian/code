    private void btnOpen_Click(object sender, EventArgs e)
    {
            OpenFileDialog o1 = new OpenFileDialog();
            o1.Filter = "INI File |*.ini";
            if (o1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                INIFile ini = new INIFile(o1.FileName);
                string user_id = ini.Read ("Profile Settings", "User ID");
                textBox1.Text = user_id;
                textBox3.Text = user_id;
                textBox4.Text = user_id;
                textBox5.Text = user_id;
                string rechini = ini.Read("Startup", "Check");
                if(rechini == "checked")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
           }
       }
    
    }
