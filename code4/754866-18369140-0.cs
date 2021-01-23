    private void txtNumber_Validating(object sender, CancelEventArgs e)
    {
        int value;
        if (!Int32.TryParse(txtNumber.Text, out value))
        {
            errorProvider.SetError(txtNumber, "Value is not an integer");
            return;
        }
        errorProvider1.SetError(txtNumber, "");
    }
