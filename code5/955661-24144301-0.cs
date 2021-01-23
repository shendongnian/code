	var lines = System.IO.File.ReadAllLines(fileName);
	var multiArr = new List<List<string>>();
	var i = 0;
	foreach (var line in lines.Where(line => line.Contains("EFIX")))
	{
		multiArr.Add(line.Split(delimiterChars).ToList());
		Console.WriteLine(fixationsData[i]);
		i++;
	}
