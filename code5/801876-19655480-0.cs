    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(@"d:\\textFile.txt");
    while ((line = file.ReadLine()) != null)
    {
        string[] words = line.Split(';');
        MessageBox.Show(line);
    }
    file.Close();
