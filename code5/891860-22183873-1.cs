    // Reads in the entire file into one string variable.
    string allTheText = File.ReadAllText(string filePath);
    
    // Splits each "file" into a string of its own.
    string[] files = allTheText.Split((char)30);
    
    // Do this if you have a newline inbetween each "file" instead of just spaces.
    string[] files = File.ReadAllLines(string filePath);
    
    // Make a Dictionary<string, string> to hold all these (you could use DateTime but I opted to not).
    Dictionary<string, string> entries = new Dictionary<string, string>();
    
    foreach(string file in files)
    {
        // Now lets get the Date of this "file".
        // We need the index of the 3rd space
        var offset = file.IndexOf(' ');
        offset = file.IndexOf(' ', offset+1);
        offset = file.IndexOf(' ', offset+1);
        
        // Now split up the string by this offset
        string date = file.Substring(0, offset-1);
        string filecont = file.Substring(offset);
    
        // Only add if it isn't already in there
        if(!entries.Keys.Contains(date))
            entries.Add(date, filecont);
    }
    
    // Print them out
    foreach(string key in entries)
    {
        Console.WriteLine(key + " " + entries[key]);
    }
