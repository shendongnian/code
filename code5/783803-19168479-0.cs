    string[] lines = System.IO.File.ReadAllLines(@"your file path");
    foreach (string line in lines)
    {
        CodeBox.Text += line;
    }
