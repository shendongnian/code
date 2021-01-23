    for (int i = 0; i < PlaceHolder1.Controls.Count; i++)
    {
        Control ctrl = PlaceHolder1.Controls[i];
        if (ctrl is TextBox)
        {
            TextBox txt = (TextBox)ctrl;
            string value = txt.Text;
        }
    }
