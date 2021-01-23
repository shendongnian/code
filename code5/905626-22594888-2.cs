    string[] lines = System.IO.File.ReadAllLines(@"a.txt");
    Label[] labels = new Label[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
    
    labels[i] = new Label();
    labels[i].Text = lines [i]    
    }
