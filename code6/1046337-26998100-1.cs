    public void AddComputerToGroups( ComputerPrincipal computer, ICollection<GroupPrincipal> groups )
    {
        var directoryEntry = (DirectoryEntry)computer.GetUnderlyingObject();
        foreach( var principal in groups.Where(g=> !computer.IsMemberOf(g) )
        {
            principal.Members.Add( computer );
            principal.Save(); // Exception thrown because computer already existed in the primary group.
        }
    }
