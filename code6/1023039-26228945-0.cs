    public void DoIt(int[] sortIndexes) 
    {
        var lines = File.ReadLines(fileInfo.FullName)
                .Select(x => x.Split('|').Reverse().ToArray())
                .OrderBy(x => 0);
    
        foreach (int index in sortIndexes) 
        {
            lines = lines.ThenBy(x => x[index]);
        }
    
        lines = lines.Select(x => string.Join("|", x));
               
    }
