    string[] lineOfContents = File.ReadAllLines(@"C:\Users\1\Desktop\2.txt");
    foreach (var line in lineOfContents)
    {
        string[] tokens = line.Split(',');
        // get the 2nd element (the 1st item is always item 0)
        comboBox1.Items.Add(tokens[1]);
    }
