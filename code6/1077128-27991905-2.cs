    lblScope.Text = "";
    foreach (Control control in PlaceHolder1.Controls)
    {
        if (control is TextBox)
        {
            TextBox txt = (TextBox)control;
            lblScope.Text += string.Format("<li>{0}</li>", txt.Text);
        }
    }
