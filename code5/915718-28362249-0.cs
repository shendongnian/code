    Feed<Group> fg = cr.GetGroups();
    foreach (Group group in fg.Entries)
    {
         Console.WriteLine("Atom Id: " + group.Id);
         Console.WriteLine("Group Name: " + group.Title);
    }
