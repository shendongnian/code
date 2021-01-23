    static string ExtractJSON(string path)
    {
        var file = File.ReadAllText(path);
        var brackets = 0;
        var json = "";
        foreach (var c in file)
        {
            if (c == '{') // if { encountered, go in a level
                brackets++;
            else if (c == '}') // if } encountered go out a level
            {
                brackets--;
                if (brackets == 0) 
                    json += c.ToString(); // get the last bracket
            }
            if (brackets > 0) // ignore everything that isn't within the brackets
                json += c.ToString();
        }
        return json;
    }
