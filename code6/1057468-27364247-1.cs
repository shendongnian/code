    File.Copy(@"1.txt", @"2.txt", true);
    string userName = System.IO.File.GetAccessControl(@"1.txt").GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
    var fs = File.GetAccessControl(@"2.txt");
    var ntAccount = new NTAccount("DOMAIN", userName);
    fs.SetOWner(ntAccount);
    
    try {
       File.SetAccessControl(@"2.txt", fs);
    } catch (InvalidOperationException ex) {
       Console.WriteLine("You cannot assign ownership to that user." +
        "Either you don't have TakeOwnership permissions, or it is not your user account."
       );
       throw;
    }
