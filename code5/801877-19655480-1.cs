    string line;
    System.IO.StreamReader file = new System.IO.StreamReader(@"d:\\textFile.txt");
    while ((line = file.ReadLine()) != null)
    {
        string output = "";
        //replacing all ';' with space
        output = line.Replace(";", " ");
        StringBuilder sb = new StringBuilder(output);
        //replacing character after number with ':'
        sb[1] = ':';
        output = sb.ToString();
        MessageBox.Show(output);
    }
    file.Close();
