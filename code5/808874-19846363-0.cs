    public static Task<IList<IContactInfo>> WhenContactsSelected(
        this ContactsSelector selector)
    {
        var tcs = new TaskCompletionSource<IList<IContactInfo>>();
        selector.ContactsSelected += (object sender, ContactsSelectorEventArgs e) =>
        {
            tcs.TrySetResult(e.Contacts);
        };
        return tcs.Task;
    }
