    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ActiveControl == listView1)
        {
            e.Handled = true; // needed to prevent an error beep
            yourLabel.Text += e.KeyChar.ToString();
        }
    }
