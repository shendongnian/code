    private void txtEstimate_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '.' && txtEstimate.Text.Contains("."))
        {
            // Stop more than one dot Char
            e.Handled = true;
        }
        else if (e.KeyChar == '.' && txtEstimate.Text.Length == 0)
        {
            // Stop first char as a dot input
            e.Handled = true;
        }
        else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
            // Stop allow other than digit and control
            e.Handled = true;
        }
    }
   
