    var users = from DirectoryEntry childEntry in hostMachineDirectory.Children
			    where childEntry.SchemaClassName == "User"
			    select childEntry;
    try { 
        var User1 = users.Single(s => s.Properties["Description"].Value.ToString().StartsWith("User1")).Name;
        Console.WriteLine("User1: " + User1);
    }
    catch (Exception e) { 
        var err = e.Message;
        Console.WriteLine("Error message: " + err);
    }
