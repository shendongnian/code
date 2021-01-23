    DirectoryEntry newComputer =
        dirEntry.Children.Add("CN=" + ComputerName, "computer");
    newComputer.CommitChanges();
    newComputer.Properties["userAccountControl"].Value = 0x200;
    newComputer.CommitChanges();
