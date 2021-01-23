    // Rename these as appropriate - and rename the textBox* variables so the names
    // explain the purpose.
    string source = textBox2.Text;
    string target = textBox4.Text;
    if (source.Contains(".xwm") && target.Contains(".xwm"))
    {
        textBox4.Text = target.Replace(".xwm", ".wav");
    }
    else if (source.Contains(".wav") && target.Contains(".wav"))
    {
        textBox4.Text = target.Replace(".wav", ".xvm");
    }
