    try
    {
        using (var directoryEntry = new DirectoryEntry(ldapPath, userName, password))
        {
            var invocation = directoryEntry.NativeObject;
            return true;
        }
     }
     catch (Exception ex)
     {
         return false;
     }
