    [DllImport("setupapi.dll", SetLastError = true)]
    public static extern bool SetupCopyOEMInf(
        string SourceInfFileName,
        string OEMSourceMediaLocation,
        OemSourceMediaType OEMSourceMediaType,
        OemCopyStyle CopyStyle,
        string DestinationInfFileName,
        int DestinationInfFileNameSize,
        ref int RequiredSize,
        string DestinationInfFileNameComponent
    );
    /// <summary>
    /// Driver media type
    /// </summary>
    internal enum OemSourceMediaType
    {
        SPOST_NONE = 0,
        //Only use the following if you have a pnf file as well
        SPOST_PATH = 1,
        SPOST_URL = 2,
        SPOST_MAX = 3
    }
    
    internal enum OemCopyStyle
    {
        SP_COPY_NEWER = 0x0000004,   // copy only if source newer than or same as target
        SP_COPY_NEWER_ONLY = 0x0010000,   // copy only if source file newer than target
        SP_COPY_OEMINF_CATALOG_ONLY = 0x0040000,   // (SetupCopyOEMInf only) don't copy INF--just catalog
    }
            
    static void Main(string[] args)
    {
        //Not really needed but I couldn't figure out how to not specify a ref parameter
        int size = 0;
        bool success = SetupCopyOEMInf("source.inf", "", OemSourceMediaType.SPOST_NONE, OemCopyStyle.SP_COPY_NEWER, null, 0,
                        ref size, null);
        if(!success)
        {
            var errorCode = Marshal.GetLastWin32Error();
            var errorString = new Win32Exception(errorCode).Message;
            Console.WriteLine(errorString);
            Console.ReadLine();
        }
    }
