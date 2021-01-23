    private void btnSubmit_Click(object sender, EventArgs e)
    {
        Regex regexIs6Digits = new Regex(@"^\d{6}$");
        if (chbxAlpha.Checked && !regexIs6Digits.IsMatch(tbxAlpha.Text))
        {
            MessageBox.Show("A valid entry requires 6 digits. Please use forward zeros if data is less than 6 digits eg 1234 = 001234.Thankyou");
            tbxAlpha.Text = "";
            tbxAlpha.Focus();
        }
        else
        {
            this.DialogResult = DialogResult.OK;
        }
        if (chbxBravo.Checked && !regexIs6Digits.IsMatch(tbxBravo.Text))
        {
            MessageBox.Show("A valid entry requires 6 digits. Please use forward zeros if data is less than 6 digits eg 1234 = 001234.Thankyou");
            tbxBravo.Text = "";
            tbxBravo.Focus();
        }
        else
        {
            this.DialogResult = DialogResult.OK;
        }
    }
