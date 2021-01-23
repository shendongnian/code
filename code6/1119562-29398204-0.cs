    public bool Read(ref byte[] bytes)
    {
        Lock.WaitOne();
        try
        {                
            using (MemoryMappedViewAccessor accessor = Mmf.CreateViewAccessor(0, DataLength))
            {
                bytes = new byte[DataLength];
                accessor.ReadArray<byte>(0, bytes, 0, DataLength);                
                return true;
            }
        }
        catch
        {
            return false;
        }
        finally
        {
            Lock.ReleaseMutex();
        }
    }
