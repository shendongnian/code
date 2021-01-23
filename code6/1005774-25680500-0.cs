    var parts = new Dictionary<string, string>(
        StringComparer.InvariantCultureIgnoreCase);
    string firstLine;
    using(var reader = new StringReader(description))
    {
        string line;
        firstLine = reader.ReadLine();
        var splitBy = new[] { ':' };
        while ((line = reader.ReadLine()) != null)
        {
            var pair = line.Split(splitBy, 2, StringSplitOptions.None);
            if (pair.Length == 2) parts[pair[0].Trim()] = pair[1].Trim();
        }
    }
    string tmp;
    string name, street, number, floor; // in your case, you could assign to
                                        // the properties directly
    name = parts.TryGetValue("Name", out tmp) ? tmp : "";
    street = parts.TryGetValue("Street", out tmp) ? tmp : "";
    number = parts.TryGetValue("Number", out tmp) ? tmp : "";
    floor = parts.TryGetValue("floor", out tmp) ? tmp : "";
