    [Flags]
    public enum FileSizeOptions 
    {
        None = 0,
        IfFileSizeIsGreaterThan = 1,
        IfFileSizeIsLowerThan = 2,
        OtherOption = 4,
        All = IfFileSizeIsGreaterThan | IfFileSizeIsLowerThan | OtherOptions
    }
    
    FileSizeOptions options = FileSizeOptions.IfFileSizeIsGreaterThan | FileSizeOptions.OtherOption;
    
    if(options.HasFlag(FileSizeOptions.All))
    {
        // Do stuff
    } else if(options.HasFlag(FileSizeOptions.IfFileSizeIsGreaterThan))
    {
       // Do stuff
    } // and so on...
