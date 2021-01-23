    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!(Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl (e.KeyChar))){
            e.Handled = true;
            Console.Beep(); 
        }
    }
