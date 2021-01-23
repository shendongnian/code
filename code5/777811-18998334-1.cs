    class Program
    {
        static FileSystemWatcher fs = null;
        static string fileName = @"c:\temp\log.txt";
        static long oldPosition = 0;
        static void Main(string[] args)
        {
            fs = new FileSystemWatcher(Path.GetDirectoryName(fileName));
            fs.Changed += new FileSystemEventHandler(fs_Changed);
            fs.EnableRaisingEvents = true;
            Console.WriteLine("Waiting for changes to " + fileName);
            Console.ReadLine();
        }
        static void fs_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath != fileName || e.ChangeType != WatcherChangeTypes.Changed) return;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader fr = new StreamReader(fs))
            {
                Console.WriteLine("{0} changed.  Old Postion = {1}, New Length = {2}", e.Name, oldPosition, fs.Length);
                if (fs.Length > oldPosition)
                {
                    fs.Position = oldPosition;
                    var newData = fr.ReadToEnd();
                    Console.WriteLine("~~~~~~ new data ~~~~~~\n" + newData);
                    oldPosition = fs.Position;
                }
            }
        }
    }
