    private static Person ParsePersonFromLine(string line)
    {
        string[] parts = line.Split(',');
        return new Person {
            Id = Int32.Parse(parts[0]),
            Name = parts[1],
            Address = parts[2],
            Contact = parts[3]
        };
    }
