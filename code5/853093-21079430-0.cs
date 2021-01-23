    var lines = File.ReadAllLines("test.txt").Skip(2).ToList();
    foreach(var line in lines)
    {
        var fileName = line.Split(new char[] { ' ' },StringSplitOption.RemoveEmptyEntries)[3]
        
        Console.WriteLine(fileName);
     }
