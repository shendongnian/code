                Object obj = new Object();
                if(appColor == "blue")
                {
                    obj = (System.Configuration.SettingsPropertyCollection)Properties.Settings.Default.Properties;
                    
                }
                else(appColor == "red")
                {
                    obj = (System.Configuration.SettingsPropertyCollection)Properties.Settings1.Default.Properties;
                }
                foreach (System.Configuration.SettingsProperty p in Properties.Settings.Default.Properties)
                {
                    if (p.Name=="Qty")
                        textBox1.Text = p.DefaultValue.ToString();
                    else if (p.Name=="Price")
                        textBox2.Text = p.DefaultValue.ToString();
                }
