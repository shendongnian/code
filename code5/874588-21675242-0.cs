             this.TxtBox.Enter += new System.EventHandler(this.TxtBox_Enter);
             private void TxtBox_Enter(object sender, EventArgs e)
             { 
                  //disable all other textboxes
                  foreach (Control c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Enabled = false;
                        }
                    }
             }
