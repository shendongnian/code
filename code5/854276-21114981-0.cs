    private void textBox_Validating(object sender, CancelEventArgs e)
    {
        TextBox tb = (TextBox)sender;
        if (String.IsNullOrEmpty(tb.Text))
        {
            errorProvider.SetError(tb, "*");
            e.Cancel = true; 
            return;          
        }
        errorProvider.SetError(tb, String.Empty);
    }
