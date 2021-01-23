    var wordslist= System.IO.File.ReadAllLines("filename")
                  .Where(x => !string.IsNullOrWhiteSpace(x))
                  .SelectMany(x => x.Split(' '));
    foreach(var word in wordlist)
    {
       Console.WriteLine("\ncapacity " + word);
    }
