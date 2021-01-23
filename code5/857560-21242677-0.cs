    using (StreamReader sr = new StreamReader("TestFile.txt"))
    {
       String line;
       String path;
       HashSet<string> paths = HashSet<string>(StringComparer.OrdinalIgnoreCase);
       // Read and process lines from the file until the end of
       // the file is reached.
       while ((line = sr.ReadLine()) != null)
       {
           Console.WriteLine(line);
           path = Path.GetDirectoryName(line);
           if(!String.IsNullOrEmpty(path)) paths.Add(path.Trim());
       }
    }
