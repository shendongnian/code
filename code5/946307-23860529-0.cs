    int seconds, minutes;
    if (textBox1.Text.Length == 1 || textBox1.Text.Length == 2)
    {
        seconds = int.Parse(textBox1.Text);
    }
    else if (textBox1.Text.Length == 3)
    {
        seconds = int.Parse(textBox1.Text.Substring(1, 2));
        minutes = int.Parse(textBox1.Text.Substring(0, 1));
    }
    else if (textbox1.Text.Length == 4)
    {
        seconds = int.Parse(textBox1.Text.Substring(2, 2));
        minutes = int.Parse(textBox1.Text.Substring(0, 2));
    }
