    private void numbers_Click(object sender, EventArgs e)
    {
        Class1 cls = new Class1();
        textBox1.Text = cls.Numbers(textBox1.Text);
    }
    public string Numbers(string text)
    {
        Button button = (Button)sender;
        text += button.Text;
        while (text != "0" && text[0] == '0' && text[1] != '.')
            text = text.Substring(1);
     
        return text;
    }
