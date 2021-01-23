    // Check for file existence
    bool DoesFileExist(string filename)
    {            
        return File.Exists(Path.Combine(GetCurrentDirectory(),filename));    
    }
    // Get current  folder directory
    string GetCurrentDirectory()
    {
        return System.IO.Path.GetDirectoryName(Host.TemplateFile);
    }
    // Get content of file name
    string OutputFile(string filename)
    {
        using(StreamReader sr = 
          new StreamReader(Path.Combine(GetCurrentDirectory(),filename)))
        {
            return sr.ReadToEnd();
        }
    }
