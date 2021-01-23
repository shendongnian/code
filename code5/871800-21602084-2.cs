    Action<string> getFile = (path) =>
        {
            while (Path.GetExtension(path) != "txt" || Path.GetExtension(path) != "xml")
            {
                Console.WriteLine("File not a .txt or .xml extension! Enter the file name:");
                path = Console.ReadLine();
            }
        };
       getFile.Invoke(@"C:\");
