    private void txtOvertimeHours_TextChanged(object sender, EventArgs e)
    {
        ZeroOutTextBox(txtOvertimeHours);
    }
    private void txtAllowance_TextChanged(object sender, EventArgs e)
    {
        ZeroOutTextBox(txtAllowance);
    }
    private void ZeroOutTextBox(Textbox txt)
    {
        if (txt.Text.Length <= 0 ||
            txt.Text == null ||
            txt.Text == "0.00" ||
            txt.Text == "0" ||
            txt.Text == "0.0")
        {
            txt.Text = "0.00";
        }
    }
