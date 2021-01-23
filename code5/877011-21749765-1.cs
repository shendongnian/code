    private String[] GetFilesByMask(string pPath)
    {
		Regex mask = new Regex(sFileMask.Replace(".", "[.]").Replace("*", ".*").Replace(".", "."));
		Return Directory.GetFiles(pPath).Where(f => mask.IsMatch(f)).ToArray();
        
    }
 
