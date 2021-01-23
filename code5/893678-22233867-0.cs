    string path=@"C:\Data.txt";
    var allText = File.ReadAllText(path);
    string [] allLines=allText.Split(new[] { "-----" }, 
                         StringSplitOptions.RemoveEmptyEntries);
    foreach (var line in allLines)
    {
    string[] allWords = line.Split(new[] { "|" }, 
                         StringSplitOptions.RemoveEmptyEntries);
     /*do some thing here*/
     /*do some thing here*/
    }
