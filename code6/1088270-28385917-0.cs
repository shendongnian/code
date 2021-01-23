    using Xamarin.Contacts;
    // ...
    
    var book = new AddressBook (this);
    if (!await book.RequestPermission()) {
        Console.WriteLine ("Permission denied by user or manifest");
        return;
    }
    
    foreach (Contact contact in book.OrderBy (c => c.LastName)) {
        Console.WriteLine ("{0} {1}", contact.FirstName, contact.LastName);
    }
