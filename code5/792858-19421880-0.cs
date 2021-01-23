    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar))
        {
            e.Handled = true;
            return;
        }
        if (e.KeyChar == '0')
        {
            if (comboBox1.Text == "")
            {
                e.Handled = true;
                return;
            }
            if (int.Parse(comboBox1.Text) == 0)
            {
                e.Handled = true;
                return;
            }
        }
    }
