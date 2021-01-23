    public IEnumerable<Person> ReadCSV(string fileName)
    {
        // We change file extension here to make sure it's a .csv file.
        // TODO: Error checking.
        string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
        // lines.Select allows me to project each line as a Person. 
        // This will give me an IEnumerable<Person> back.
        return lines.Select(line =>
        {
            string[] data = line.Split(';');
            // We return a person with the data in order.
            return new Person(data[0], data[1], Convert.ToInt32(data[2]), data[3]);
        });
    }
