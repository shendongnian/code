    string needle = "\r\r";  // only one possible cause of empty lines
    int p1 = richTextBox1.Find(needle);
    while (p1 >= 0)
    {
        richTextBox1.SelectionStart = p1;
        richTextBox1.Select(p1, needle.Length);
        richTextBox1.Cut();
        p1 = richTextBox1.Find(needle);
    }
