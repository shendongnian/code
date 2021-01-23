    StreamReader fileIn = new StreamReader(fileName);
    for(int i=0; i<4 && !fileIn.EndOfStream; ++i)
    {
        string line = fileIn.ReadLine();
        if(line.Length > 40)
            richTextBox1.AppendText(line.Substring(0,40) + Environment.NewLine);
        else
            richTextBox1.AppendText(line + Environment.NewLine);
    }
    int j;
    for(j=0; !fileIn.EndOfStream; ++j)
        fileIn.ReadLine();
    if(j>0)
        richTextBox1.AppendText(j.ToString() + " more lines are not shown.";
    fileIn.Close();
