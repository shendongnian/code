    string[] names = new string[] { "Matt", "Joanne", "Robert" };
    Array.Resize(ref names, names.Length + 1);
    names[names.Length - 1] = "Steve";
    foreach (string i in names)
    {
        richTextBox1.AppendText(i + Environment.NewLine);
    }
