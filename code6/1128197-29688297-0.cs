    string path = "C:\test";
    if (File.Exists(path))
    {
        string[] fileContents = File.ReadAllLines(path);
        if (fileContents.Length > 0)
        {
            richTextBox1.Clear();
            foreach (string line in fileContents)
            {
                richTextBox1.AppendText(line + Environment.NewLine);
            }
        }
    }
