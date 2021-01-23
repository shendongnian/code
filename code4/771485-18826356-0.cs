    foreach (string file in Directory.EnumerateFiles(fbd.SelectedPath, "*.Designer.cs"))
    {
        int counter = 0;
        string line;
        Regex r = new Regex(@"this.label1.Text[ ]*[\=]{1}[ ]*[\""]{1}(?<Value>[a-zA-Z0-9 ]*)[\""]{1}[ ]*[\;]{1}");
        // Read the file and display it line by line.
        StreamReader CurrentFile = new StreamReader(file);
        while ((line = CurrentFile.ReadLine()) != null)
        {
            bool typeOne = line.Contains(".Text=");
            bool typeTwo = line.Contains(".Text =");
            if ((typeOne == true) || (typeTwo == true))
            {
              Match m=r.Match(line);
              string thevalueyouneed=m.Groups[1].Value;//This is what you need.
              //Do other things with this value.  
            }
            counter++;
        }
        CurrentFile.Close();
    }
