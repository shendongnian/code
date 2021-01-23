         byte[] image = Convert.FromBase64String(content);
         string extensao = GetMimeFromBytes(image);
    
    
    public static int MimeSampleSize = 256;
    
            public static string DefaultMimeType = "application/octet-stream";
    
            [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
            private extern static uint FindMimeFromData(
                uint pBC,
                [MarshalAs(UnmanagedType.LPStr)] string pwzUrl,
                [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
                uint cbSize,
                [MarshalAs(UnmanagedType.LPStr)] string pwzMimeProposed,
                uint dwMimeFlags,
                out uint ppwzMimeOut,
                uint dwReserverd
            );
    
            public static string GetMimeFromBytes(byte[] data)
            {
                try
                {
                    uint mimeType;
                    FindMimeFromData(0, null, data, (uint)MimeSampleSize, null, 0, out mimeType, 0);
    
                    var mimePointer = new IntPtr(mimeType);
                    var mime = Marshal.PtrToStringUni(mimePointer);
                    Marshal.FreeCoTaskMem(mimePointer);
    
                    return mime ?? DefaultMimeType;
                }
                catch
                {
                    return DefaultMimeType;
                }
            }
