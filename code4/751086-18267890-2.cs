    int bps = ... // Use int!
    long TotalSectors = ... // use long!
    long pos = 0; // use long!
    for (long idx = 0; idx < TotalSectors; idx++)
    {
        File.Write(writeBuffer, (uint)writeBuffer.Length);  // write the buffer
        pos += bps;
        File.MoveFilePointer(pos);
        Application.DoEvents();
    }
