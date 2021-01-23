    String[] txt = richTextBox1.Lines;
    bool flag = false;
    for (int i = 0; i < txt.Length; i++)
    {
        if (txt[i].StartsWith("ALTER TABLE") && txt[i].Contains("MOVE STORAGE"))
           flag = true;
        if (string.IsNullOrEmpty(txt[i]))
           flag = false;
    
         if (flag)
           txt[i] = string.Empty;
     }
     richTextBox1.Lines = txt;
