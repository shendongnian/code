    string[] lineOfContents = File.ReadAllLines(@"C:\Users\1\Desktop\2.txt");
    foreach (var line in lineOfContents)
    {
        string[] tokens = line.Split(',');
        if(tokens.Length >= 2)
           comboBox1.Items.Add(tokens[1]);
    }
