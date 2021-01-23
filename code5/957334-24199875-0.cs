    public class Program
    {
        public static void Main(string[] args)
        {
            var source = @"C:\doc";
            var target = @"C:\doc2";
            while (true)
            {
                using (var folderWatcher = new FileSystemWatcher(source))
                {
                    folderWatcher.Filter = "*.*";
                    Console.WriteLine("Watching " + source);
                    var change = folderWatcher.WaitForChanged(WatcherChangeTypes.Created, 1000 * 60);
                    
                    if (!change.TimedOut)
                    {
                        Console.WriteLine("File detected: " + change.Name);
                        Console.WriteLine("Moving to: " + target);
                        File.Move(Path.Combine(source, change.Name), Path.Combine(target, change.Name));
                    }
                }
            }
        }
    }
