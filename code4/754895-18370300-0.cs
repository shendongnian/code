        string[] names = { "John", "Doe" };
        List<string> namesList = new List<string>(names);
        // OR
        List<string> namesList2 = new List<string>();
        foreach (string name in names)
        {
            namesList2.Add(name);
        }
