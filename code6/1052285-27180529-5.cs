    foreach(Control ctl in groupBox1.Controls)
        {
            if (ctl is Button)
            {
                ctl.Click += button_Click;
            }
        }
