    using (DirectoryEntry entry = new DirectoryEntry("WinNT://./Users,group")) 
    {
        foreach (object member in (IEnumerable)entry.Invoke("Members"))
        {
            using(DirectoryEntry m = new DirectoryEntry(member))
            {
                Response.Write(m.Name);
            }
        }
    }
