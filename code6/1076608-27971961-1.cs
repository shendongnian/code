    String executingFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
    String executingDirectory = System.IO.Path.GetDirectoryName( executingFileName );
    
    UInt64 userFreeBytes, totalDiskBytes, totalFreeBytes;
    if( GetDiskFreeSpaceEx( executingDirectory, out userFreeBytes, out totalDiskBytes, totalFreeBytes ) {
        // `userFreeBytes` is the number of bytes available for your program to write to on the mounted volume that contains your application code.
    }
