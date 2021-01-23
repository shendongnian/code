    for (int i = 0; i < ptrsize; i++)
    {  
    richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(linenum[i]),richTextBox1.Lines[linenum[i]].Length);
    richTextBox1.SelectionColor = Color.Red;
    }
