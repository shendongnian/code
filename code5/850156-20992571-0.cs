    // Create hash list to hold allowed users
    HashSet<string> allowed_users = new HashSet<string>();
    
    // Add users here
    
    // Get current user
    var entry = new DirectoryEntry("WinNT://" + a[0] + "/" + a[1]);
    var username = entry.Properties["FullName"].Value.ToString();
    
    // Toggle link button
    LinkButton.Visible = allowed_users.Contains(username);
