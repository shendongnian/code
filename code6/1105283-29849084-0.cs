    public static void DeleteContact(Context context, string lookupKey)
    {
        var uri = Uri.WithAppendedPath(ContactsContract.Contacts.ContentLookupUri, lookupKey);
        context.ContentResolver.Delete(uri, null, null);
    }
