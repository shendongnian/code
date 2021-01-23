    public bool null2 (Control control) 
    {
        foreach (TextBox t in control.Controls.OfType<TextBox>())
        {
            if (string.IsNullOrWhiteSpace(t.Text))
            {
                MessageBox.Show("Not happening bro...");
                errorProvider1.SetError(textbox, "Cannot be Empty");
                return(false) ;
            }
        }
        return(true);
    }
