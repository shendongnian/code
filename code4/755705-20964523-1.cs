    IntPtr unmanagedBytes = Marshal.SecureStringToGlobalAllocUnicode(password);
    byte[] bValue = null;
    try
    {
        byte* byteArray = (byte*)unmanagedBytes.GetPointer();
        // Find the end of the string
        byte* pEnd = byteArray;
        char c='\0';
        do
        {
            byte b1=*pEnd++;
            byte b2=*pEnd++;
            c = '\0';
            c= (char)(b1 << 8);                 
            c += (char)b2;
        }while (c != '\0');
        // Length is effectively the difference here (note we're 2 past end) 
        int length = (int)((pEnd - byteArray) - 2);
        bValue = new byte[length];
        for (int i=0;i<length;++i)
        {
            // Work with data in byte array as necessary, via pointers, here
            bValue[i] = *(byteArray + i);
        }
    }
    finally
    {
        // This will completely remove the data from memory
        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedBytes);
    }
