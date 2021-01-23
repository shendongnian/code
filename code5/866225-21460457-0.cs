    var abook = new AddressBook();
    abook.RequestPermissions().ContinueWith (t =>
    {
        if (!t.Result)
            return; // Permission denied
        var builder = new StringBuilder();
	
        // Full LINQ support
        foreach (Contact c in abook.Where (c => c.FirstName == "Eric" && c.Phones.Any()))
        {
            builder.AppendLine (c.DisplayName);
            foreach (Phone p in c.Phones)
                builder.AppendLine (String.Format ("{0}: {1}", p.Label, p.Number));
            builder.AppendLine();
        }
	
        contacts.Text = builder.ToString(); // Update UI
	
    }, TaskScheduler.FromCurrentSynchronizationContext()); // Ensure we're on the UI Thread
