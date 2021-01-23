    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        if (i > 8)
        {
            textBox1.Text += line + Environment.NewLine;
        }
        i++;
    }
