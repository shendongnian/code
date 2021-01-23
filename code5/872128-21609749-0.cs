    var filenames4 =  System.IO.Directory
                .EnumerateFiles("X:\\files\\", "*", System.IO.SearchOption.AllDirectories)
                .Select(System.IO.Path.GetFileName); 
     foreach (var file in filenames4)
            {
                Console.WriteLine("{0}", file);
            }
