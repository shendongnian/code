    for (int i = 0; i < richTextBox1.Lines.Length; i++)
    {
        if (richTextBox1.Lines[i] == "ok")
        {
            string[] lines = richTextBox1.Lines;
            lines[i] = "done";
            richTextBox1.Lines = lines;
        }
    }
