    private void textBox1_TextChanged(object sender, EventArgs e)
    {
       foreach (Control control in this.Controls)
       {
          // Skip, if the control is the used TextBox
          if (control == textBox1) { continue; }
          // Show all controls where name starts with inputed string
          // (use ToLower(), so casing doesnt matter)
          if (control.Name.ToLower().StartsWith(textBox1.Text.Trim().ToLower()))
          {
             control.Visible = true;
          }
    
          // Hide objects that doesn't match
          else { control.Visible = false; }
       }
    }
