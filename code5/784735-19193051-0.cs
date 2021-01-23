    unsafe static long DumbDifference(string file1Path, string file2Path)
    {
        // completely untested! also, add some using()s here.
        // also, map views in chunks if you plan to use it on large files.
        MemoryMappedFile file1 = MemoryMappedFile.CreateFromFile(
                 file1Path, System.IO.FileMode.Open,
                 null, 0, MemoryMappedFileAccess.Read);
        MemoryMappedFile file2 = MemoryMappedFile.CreateFromFile(
                 file2Path, System.IO.FileMode.Open,
                 null, 0, MemoryMappedFileAccess.Read);
        MemoryMappedViewAccessor view1 = file1.CreateViewAccessor();
        MemoryMappedViewAccessor view2 = file2.CreateViewAccessor();
        long length1 = checked((long)view1.SafeMemoryMappedViewHandle.ByteLength);
        long length2 = checked((long)view2.SafeMemoryMappedViewHandle.ByteLength);
        long minLength = Math.Min(length1, length2);
        byte* ptr1 = null, ptr2 = null;
        view1.SafeMemoryMappedViewHandle.AcquirePointer(ref ptr1);
        view2.SafeMemoryMappedViewHandle.AcquirePointer(ref ptr2);
        ulong differences = (ulong)Math.Abs(length1 - length2);
        for (long i = 0; i < minLength; ++i)
        {
            // if you expect your files to be pretty similar,
            // you could optimize this by comparing long-sized chunks.
            differences += ptr1[i] != ptr2[i] ? 1u : 0u;
        }
        return checked((long)differences);
    }
