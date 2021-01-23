    public static Task<IEnumerable<Contact>> SearchTaskAsync(this Contacts contacts, string filter, FilterKind filterKind)
    {
      var tcs = new TaskCompletionSource<IEnumerable<Contact>>();
      EventHandler<ContactsSearchEventArgs> subscription;
      subscription = (_, args) =>
      {
        contacts.SearchComplete -= subscription;
        try
        {
          tcs.TrySetResult(args.Results);
        }
        catch (Exception ex)
        {
          tcs.TrySetException(ex);
        }
      }
      contacts.SearchComplete += subscription;
      contacts.SearchAsync(filter, filterKind, null);
      return tcs.Task;
    }
