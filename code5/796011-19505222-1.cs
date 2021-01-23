        List<string> lines = new List<string>(File.ReadAllLines("Students.txt"));
        string newLastName = "'Constant";
        string newRecord = "(LIST (LIST 'Constant 'Malachi 'D ) '1234567890 'mdcant@mail.usi.edu 4.000000 )";
        string line;
        string lastName;
        bool insertionPointFound = false;
        for (int i = 0; i < lines.Count && !insertionPointFound; i++)
        {
            line = lines[i].Trim();
            if (line.StartsWith("(LIST (LIST "))
            {
                values = line.Split(" ".ToCharArray());
                lastName = values[2];
                if (newLastName.Equals(lastName))
                {
                    lines.Insert(i, newRecord);
                    insertionPointFound = true;
                }
            }
         }
         if (!insertionPointFound)
             lines.Add(newRecord);
