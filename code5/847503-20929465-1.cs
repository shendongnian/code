    IDictionary<String, BookmarkStart> bookmarkMap = 
         new Dictionary<String, BookmarkStart>();
    // get all
    foreach (BookmarkStart bookmarkStart in file.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
    {
        bookmarkMap[bookmarkStart.Name] = bookmarkStart;
    }
    // get their text
    foreach (BookmarkStart bookmarkStart in bookmarkMap.Values)
    {
      Run bookmarkText = bookmarkStart.NextSibling<Run>();
      if (bookmarkText != null)
      {
          string bookmarkText = bookmarkText.GetFirstChild<Text>().Text;
      }
    }
