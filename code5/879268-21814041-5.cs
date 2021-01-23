    public IEnumerable<Person> ReadCSV(string fileName)
    {
        // We change file extension here to make sure it's a .csv file.
        string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
        return lines.Select(l =>
        {
            string[] data = l.Split(';');
            return new Person(data[0], data[1], Convert.ToInt32(data[2]), data[3]);
        });
    }
