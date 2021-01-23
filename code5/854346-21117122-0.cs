    var parsedList = new List<Stuff>();
    string[] lines = System.IO.File.ReadAllLines(@"C:\input.txt");
    foreach (var line in lines)
    {
        var lineSplit = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var stuff = new Stuff(lineSplit[0], Int32.Parse(lineSplit[1]), decimal.Parse(lineSplit[2]), double.Parse([3])  );
        parsedList.Add(stuff);
    }
    Stuff[]  arrayOfStuff = parsedList.ToArray();
