    while (line != null)
    {
        richTextBox1.AppendText(Environment.NewLine);        
        line = sr.ReadLine();
        richTextBox1.AppendText(line??"");
    }
