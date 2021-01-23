    public static Task<IEnumerable<Contact>> SearchTaskAsync(this Contacts contacts, string filter, FilterKind filterKind)
    {
      var tcs = new TaskCompletionSource<IEnumerable<Contact>>();
      EventHandler<ContactsSearchEventArgs> subscription = null;
      subscription = (_, e) =>
      {
        contacts.SearchCompleted -= subscription;
        tcs.TrySetResult(e.Results);
      };
      contacts.SearchCompleted += subscription;
      contacts.SearchAsync(filter, filterKind, null);
      return tcs.Task;
    }
