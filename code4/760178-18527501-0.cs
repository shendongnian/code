    public string[] newestFile(string path){    
        IEnumerable<string> files = new string[]{};
        foreach (var item in dir.GetDirectories(Path.Combine(path,"*.*"), SearchOption.AllDirectories))
        {
           try {
            files = files.Concat(item.GetFiles().OrderByDescending(f => f.LastWriteTime).First());
           }
           catch {}
        }   
        return files.ToArray();  
    }
