    private static void Confirmation_Click(Form prompt)
    {
        TextBox textBox = prompt.Controls.Find("the_textBox", false).FirstOrDefault() as TextBox;
        if(textBox == null)
            return; //uhm weird
       
        bool k = IsValidPrice(textBox.Text);
        if (k)
            prompt.Close();
        else 
            textBox.Focus();
    }
