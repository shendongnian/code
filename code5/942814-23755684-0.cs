     private void textBox1_TextChanged(object sender, EventArgs e)
         {
            foreach (Control c in fl_panel.Controls)
            {              
                if (c.Name.StartsWith(textBox1.Text.ToString()) && textBox1.Text != "")
                {
                    Control[] ctrls = fl_panel.Controls.Find(textBox1.Text.ToString(), true);
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
