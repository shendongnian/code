    // List to store all bookmarks sorted by position.
    List<Bookmark> bmList = new List<Bookmark>();
    // Iterate over all the Bookmarks and add them to the list (unordered).
    foreach (Bookmark curBookmark in MergeResultDoc.Bookmarks)
    {
        bmList.Add(curBookmark);
    }
    // Sort the List by the Start member of each Bookmark.
    // After this line the bmList will be ordered.
    bmList.Sort(delegate(Bookmark bm1, Bookmark bm2)
    {
        return bm1.Start.CompareTo(bm2.Start);
    });
