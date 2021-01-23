    textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
    textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
    private void textBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(e.KeyChar == '\r')
        {
            e.Handled = true;
            // some other stuff
            Console.WriteLine(((TextBox)sender).Name); //actual textbox name
        }
    }
