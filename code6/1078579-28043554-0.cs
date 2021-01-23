        Process test = new Process();
    
        string FileName = "prefs.dat";
        StreamReader sr = new StreamReader(FileName);
        List<string> lines = new List<string>();
        lines.Add(sr.ReadLine()); 
        lines.Add(sr.ReadLine());
        string s1 = lines[0];
        string s2 = lines[1]; // Now you can access second line
        sr.Close();
        test.StartInfo.FileName = s;
        test.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        test.StartInfo.CreateNoWindow = false;
        test.Start();
