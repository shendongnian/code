    Func<Pug_DriveType, Task<ManagementObjectCollection>> ReadTask = (Pug_DriveType DT) =>
    {
    
        StringBuilder Query =
            new StringBuilder("SELECT * FROM Win32_LogicalDisk WHERE DriveType=\"")
            .Append((int)DT).Append("\"");
    
        ManagementObjectSearcher Search = new ManagementObjectSearcher(Query.ToString());
    
        Task.Run(() => Search.Get());
    };
