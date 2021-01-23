    var users = from DirectoryEntry childEntry in hostMachineDirectory.Children
			    where childEntry.SchemaClassName == "User"
			    select childEntry;
    try { 
        var UserName = users.Single(s => s.Properties["Description"].Value.ToString().StartsWith("Whatever description")).Name;
        Console.WriteLine("User: " + UserName);
    }
    catch (Exception e) { 
        var err = e.Message;
        Console.WriteLine("Error message: " + err);
    }
