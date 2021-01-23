    string savedUrl = string.Format("{0}.jpeg", ld.Title);
    using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
    {
        if (!iso.FileExists(savedUrl))
        {
            savedUrl = null;
        }
    }
