    internal static bool ReadAsDirectoryEntry(BinaryReader br)
    {
        bool dir;
        // Skip 8 bytes starting from current position
        br.BaseStream.Seek(8, SeekOrigin.Current);
        
        // Read next bytes as an Int32 which requires 32 bits (4 bytes) to be read 
        // Store whether or not this integer value is less then zero
        // Possibly it is a flag which holds some information like if it is a directory entry or not
        dir = br.ReadInt32() < 0;
        // Till here, we read 12 bytes from stream. 8 for skipping + 4 for Int32
        // So reset stream position to where it was before this method has called
        br.BaseStream.Seek(-12, SeekOrigin.Current);
        return dir;
    }
