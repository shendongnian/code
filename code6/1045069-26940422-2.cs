    public void do_name()
    {
        string[] search_text = new string[] { "PCB", "DOC", "PCB1", "DOC1" };
        string old;
        StringBuilder sb = new StringBuilder();
        using (StreamReader sr = File.OpenText(textBox1.Text))
        {
            while ((old = sr.ReadLine()) != null)
            {
                if (old.Length > 0) // if not a zero length string
                {
                    old = old.Substring(0, old.LastIndexOf("\t"));
                }
                if (old.Contains(search_text[0]) || old.Contains(search_text[1]) ||
                    old.Contains(search_text[2]) || old.Contains(search_text[3]) ||
                    old.Split('\t').Contains(@"""0"""))
                    continue;
                else
                    sb.AppendLine(old);
            }
            sr.Close();
       }
       File.WriteAllText(textBox1.Text, sb.ToString());
    }
