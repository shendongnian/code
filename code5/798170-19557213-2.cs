        // List to store Key names
        List<string> names = new List<string>();                                                 
        // List to store key values
        List<List<string>> values = new List<string>();                                               
        using (StreamReader stream = new StreamReader(filePath))
        {
            if(!stream.EndOfStream)
            {
                // Seperate key names and store them in a List
                names = stream.ReadLine().Split(',').ToList();
            }                     
            while(!stream.EndOfStream)
            {
                // Seperate key values and store them in a list
                values.Add(stream.ReadLine().Split(',').ToList());                 
            }
        }
