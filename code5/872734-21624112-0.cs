    namespace FileWatchTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(@"c:\temp");
                watcher.EnableRaisingEvents = true;
                watcher.Created += (obj, arg) => Console.WriteLine("File {0} created", arg.Name);
                watcher.Deleted += (obj, arg) => Console.WriteLine("File {0} deleted", arg.Name);
                watcher.Changed += (obj, arg) => Console.WriteLine("File {0} changed", arg.Name);
                Console.ReadLine();
            }
        }
    }
