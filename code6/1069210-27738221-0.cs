    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        var textBox=(TextBox)sender; //text box which raised the event
        if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == '.' && !textBox.Text.Contains('.'))
        {
            return;
        }
        else if (e.KeyChar == (char)Keys.Back)
        {
            return;
        }
        else if (e.KeyChar == '.' && !textBox.Text.Contains('.'))
        {
            return;
        }
        else
        {
            e.Handled = true;
            Console.Beep(1000, 500);
            MessageBox.Show("Only numbers allowed!","Error");
        }
     }
