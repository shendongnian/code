    private IEnumerable<string[]> ReadCsv(string fileName, char delimiter = ';')
    {
    	var lines = System.IO.File.ReadAllLines(fileName, Encoding.UTF8).Select(a => a.Split(delimiter));
    	return (lines);
    }
