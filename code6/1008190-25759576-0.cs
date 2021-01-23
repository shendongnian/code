    private void button1_Click(object sender, EventArgs e)
    {
        Regex phoneNumpattern = new Regex(@"\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{5}\s+[0-9]{3}");
        if (phoneNumpattern.IsMatch(textBox1.Text))
        {
            MessageBox.Show("OK");
        }
        else
        {
            MessageBox.Show("Invalid phone number");
        }
    }
