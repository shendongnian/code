     private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (txtPrice.Text.Length == 0)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
        {
            e.Handled = true;
        }
        if (e.KeyChar == '.' && txtPrice.Text.IndexOf('.') > -1)
        {
            e.Handled = true;
        }
    }
