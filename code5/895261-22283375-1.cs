        string fileList = @"d:\temp\list.txt";
        if (File.Exists(fileList))
        {
            var files = File.ReadAllLines(fileList).Where(x => !File.Exists(x));
            if(files.Count() > 0)
            {
                foreach(string missing in files)
                   Console.WriteLine("File missing: " + missing);
                throw new FileNotFoundException("Some files are missing");
            }
        }
        else
        {
            Console.WriteLine("Cannot find list file");
        }
