    private static int counter;
    private static string[] currentLines;
    private static void Main(string[] args)
    {
        FileSystemWatcher watcher = new FileSystemWatcher("myfile.txt");
        watcher.Changed += fileChanged;
        currentLines = File.ReadLines("myFile.txt").ToArray();
        counter = currentLines.Length;
        Console.ReadLine();
    }
    private static void fileChanged(object sender, FileSystemEventArgs e)
    {
         var temp = File.ReadLines("myFile.txt").Skip(counter).ToArray();
         if (temp.Any())
         {
             currentLines = temp;
             counter += temp.Length;
         }
    }
