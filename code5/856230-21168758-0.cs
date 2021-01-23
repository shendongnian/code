    List<string> AllFiles = new List<string>();
    AllFiles.Concat(filesHD.ToList());
    AllFiles.Concat(filesDT.ToList());
    AllFiles.Concat(filesTD.ToList());
        
    var strAllFiles = AllFiles.ToArray();
