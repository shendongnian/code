    public List<string> GetSatelliteNames(string input)
    {
        string[] split = input.split(new string[2] { "\n", "\r\n" });
        List<string> result = new List<string>();    
        foreach (var s in split)
        {
            string splitagain = s.split(new char[1] { ' ' });
            if (s[0] == "0") result.add(s[1]);
        }
        return result;
    }
