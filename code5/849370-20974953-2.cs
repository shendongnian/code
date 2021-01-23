    private void textBox1_Leave(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(textBox1.Text))
        {
                         errorProvider.SetError(textBox1,"REQUIRED FIELD");
                         label12.Text = "REQUIRED FIELD";
        }
        else
        {
            errorProvider.SetError(textBox1, String.Empty); // to clear only the error for this text box
            // errorProvider.Clear(); // to clear all errors for this provider
        }
    }
