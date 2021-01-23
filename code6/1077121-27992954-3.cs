    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
    	if (!Char.IsDigit(e.KeyChar))
    	{
    		MessageBox.Show("insert numbers only");
    		e.Handled = true;
    	}
    }
