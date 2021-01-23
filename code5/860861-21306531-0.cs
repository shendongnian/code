     public static void trimRecursive(Control root)
        {
          foreach (Control control in root.Controls)
          {
            if (control is TextBox)
            {
                var textbox = control as TextBox;
                textbox.Text = textbox.Text.Trim();
            }
            else
            {
                trimRecursive(control);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        trimRecursive(Page);
    }
