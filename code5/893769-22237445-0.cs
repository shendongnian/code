    IEnumerable<string> SearchAccessibleFiles(string root, string searchTerm) {
        var files = new List<string>();
        foreach (var file in Directory.GetFiles(root)
                                 .Where(m => m.Contains(searchTerm))) 
        {
            files.Add(file);
        }
        foreach (var subDir in Directory.GetDirectories(root)) {
            try {
                files.AddRange(GetAllAccessibleFiles(subDir, searchTerm));
            }
            catch (UnauthorizedAccessException ex) {
                // ...
            }
        }
        return files;
    } 
