    [DllImport(dllPath, CharSet = CharSet.Unicode, SetLastError = true, CallingConvention =     CallingConvention.Cdecl)]
    internal static extern FETCH HttpFetchW(
        string url,
        out System.Runtime.InteropServices.ComTypes.IStream retval,
        string usrname,
        string pwd,
        bool unzip,
        dlgDownloadingCB cb,
        IntPtr cb_param,
        string ctype,
        uint ctypelen
    );
