    List<string> readIt(string fileName)
    {
        string line;
        List<string> data = new List<string>();
        StreamReader file = new StreamReader(fileName);
        while((line = file.ReadLine()) != null)
        { if (line!="") data.Add(line); }
        file.Close();
        return data;
    }
