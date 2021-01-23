    string[] lines = System.IO.File.ReadAllLines(@"a.txt");
    Labels[] labels = new Labels[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
    
    labels[i] = new Label();
    lables[i].Text = lines [i]    
    }
