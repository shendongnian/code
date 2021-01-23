        List<string> names = new List<string>();                                                 // List to store Key names
        List<List<string>> values = new List<string>();                                               // List to store key values
        using (StreamReader stream = new StreamReader(filePath))
        {
            if(!stream.EndOfStream)
                names = stream.ReadLine().Split(',').ToList();                  // Seperate key names and store them in a List
            while(!stream.EndOfStream)
            {
                values.Add(stream.ReadLine().Split(',').ToList());                 // Seperate key values and store them in a list
            }
        }
