    List<string> rt = new List<string>();
    bool doAdd = true;
    foreach (string line in richTextBox1.Lines)
    {
        if (doAdd)
        {
            rt.Add(line);
            doAdd = true;
        }
        if (string.IsNullOrEmpty(line))
        {
              doAdd = false;
        }
        else
        {
             if (!doAdd)
               rt.Add(line);
             doAdd = true;
        }
    }
    richTextBox1.Lines = rt.ToArray();
