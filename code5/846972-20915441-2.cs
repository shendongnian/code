            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F1)
                {
                    foreach (Control c in this.Controls)
                    {
                        string hName = "help_" + c.Name;
                        Control[] help = this.Controls.Find(hName, true);
                        if (help.Length>0)
                        {
                            c.Controls.Add(help[0]);
                        }
                    }
                }
            }
    
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F1)
                {
                    foreach (Control c in this.Controls)
                    {
                        string hName = "help_" + c.Name;
                        Control[] help = c.Controls.Find(hName, true);
                        if (help.Length > 0)
                        {
                            c.Controls.Remove(help[0]);
                        }
                    }
                }
            }
