    foreach (Control c in this.Controls)
    {
        if (c is TextBox && c.Text.Length==0 && c.Tag is Label)
        {
            ((Label)c.Tag).ForeColor = System.Drawing.Color.Red;
            err = true;
        }
    }
