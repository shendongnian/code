     private void textBox1_TextChanged(object sender, EventArgs e)
         {
            foreach (Control c in fl_panel.Controls)
            {              
                if (c.Name.ToUpper().StartsWith(textBox1.Text.ToUpper().ToString()) && textBox1.Text != "")
                {
                    Control[] ctrls = fl_panel.Controls.Find(textBox1.Text.ToString(), true);
                    c.Visible = true;  // to restore previous matches if I delete some text
                }
                
                else if(textBox1.Text == "")
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }                      
            }
        }
