    if(!Directory.Exists(path) {
        //error handling here
    }
    
    foreach (string subDir in Directory.GetDirectories(path))
    {
        queue.Enqueue(subDir);
    }
