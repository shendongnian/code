    int i = 0;
    foreach (Control control in PlaceHolder1.Controls)
    {
        if (control is TextBox)
        {
            if (i == 0)
                continue;
            TextBox txt = (TextBox)control;
            lblScope.Text += string.Format("<li>{0}</li>", txt.Text);
            i++;
        }
    } 
