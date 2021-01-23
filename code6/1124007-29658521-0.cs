    private void AddMemberToGroup(string bindString, string newMember)
    {
        try
        {
            DirectoryEntry ent = new DirectoryEntry(bindString);
            ent.Properties["member"].Add(newMember);
            ent.CommitChanges();
        }
        catch (Exception e)
        {
            // do error catching stuff here
            return;
        }
    }
