    private void InsertIntoBookmark(string bookmarkName, string text)
    {
        if (Document != null && Document.Bookmarks.Exists(bookmarkName))
        {
            var range = Document.Bookmarks[bookmarkName].Range;
            Document.Bookmarks[bookmarkName].Delete();
            range.Text = text;
            // replace bookmark
            Document.Bookmarks.Add(bookmarkName, range);
        }
    }
