    string msg1 = "This is a Windows operating system.";
    string msg2 = "This is a Unix operating system.";
    string msg3 = "This is a OSX operating system.";
    string msg4 = "ERROR: This platform identifier is invalid.";
    OperatingSystem os = Environment.OSVersion;
    PlatformID pid = os.Platform;
    switch (pid) 
    {
        case PlatformID.Win32NT:
        case PlatformID.Win32S:
        case PlatformID.Win32Windows:
        case PlatformID.WinCE:
            Console.WriteLine(msg1);
         break;
        case PlatformID.Unix:
            Console.WriteLine(msg2);
         break;
        case PlatformID.MacOSX:
            Console.WriteLine(msg3);
         break;
        default:
            Console.WriteLine(msg4);
         break;
    }
