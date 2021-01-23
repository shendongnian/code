    var path = @"C:\Users\XXXXX\Desktop\testfile";
    var ext  = ".datafile";
    var range = Enumerable.Range(0,3);
    var filePaths = 
                 from i in range
                 from j in range
                 let file = path + i + j+ ext
                 where File.Exists(file)
                 select File.ReadLines(f)
                            .SkipWhile(line => !line.Contains("#Footer"))
                            .Skip(1);
    try{
       Console.WriteLine(String.Join(Environment.NewLine,filePaths.SelectMany(f => f));
    } catch (Exception e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        Console.Read();
    }
                            
