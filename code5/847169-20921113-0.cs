    string[] lines = File.ReadAllLines(path);
    foreach(var line in lines)
    {
      var firstValue = line.Split(new string[]{"        "}, StringSplitOptions.RemoveEmptyEntries)[0];
      Console.WriteLine(firstValue);
    }
