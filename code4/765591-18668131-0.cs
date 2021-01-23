        string line;
        var sb = new StringBuilder();
        System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
        while ((line = file.ReadLine()) != null)
            sb.AppendLine(line.Substring(0, 38));
        file.Close();
        using (System.IO.StreamWriter files = new System.IO.StreamWriter(@"C:\test2.txt"))
            {
                files.WriteLine(sb.ToString());
            }
