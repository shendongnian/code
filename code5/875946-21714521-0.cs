       internal static void AddFile(Alphaleonis.Win32.Filesystem.FileInfo finfo, FileClass theClass)
       {
           theClass.FileID = FileIDCounter;
           theClass.Name = finfo.Name;
           theClass.FullName = finfo.FullName;
           theClass.Attributes = GetFileAttributes(finfo);
           theClass.CreationTime = finfo.CreationTime;
           theClass.Extension = finfo.Extension;
           theClass.isReadOnly = finfo.IsReadOnly;
           theClass.LastAccessTime = finfo.LastAccessTime;
           theClass.LastWriteTime = finfo.LastWriteTime;
           theClass.Length = finfo.Length;
    
           Interlocked.Increment(ref FileIDCounter); // As a Static value this is shared amongst all the instances of the class
           // Interlocked.Increment is the Thread Safe way of saying FileIDCounter ++;
    
           FileClassList.Add(theClass);
           if (FileClassFileAdded != null) FileClassFileAdded(theClass);
    
       }
