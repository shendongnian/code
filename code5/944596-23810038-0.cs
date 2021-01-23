    using (DirectoryEntry user = new DirectoryEntry("WinNT://./UserAccount,user"))
    {
        foreach(object group in (IEnumerable)user.Invoke("Groups",null)) 
        { 
            using(DirectoryEntry g = new DirectoryEntry(group))
            {
                Response.Write(g.Name);
            }
        } 
    }
