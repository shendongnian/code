    var lines = File.ReadAllLines("test.txt").Skip(2).ToList();
    foreach(var line in lines)
    {
        var fileName = line.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)[3]
        
        Console.WriteLine(fileName);
     }
