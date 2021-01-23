       internal static void AddFile(Alphaleonis.Win32.Filesystem.FileInfo finfo, FileClass theClass)
       {
   
           Interlocked.Increment(ref FileIDCounter); // As a Static value this is shared amongst all the instances of the class
           // Interlocked.Increment is the Thread Safe way of saying FileIDCounter ++;
    
           FileClassList.Add(theClass);
           if (FileClassFileAdded != null) FileClassFileAdded(theClass);
    
       }
