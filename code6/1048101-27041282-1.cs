    // Create a list for the bookmarks
    List<Dictionary<String, Object>> bookmarks = 
        new List<Dictionary<String, Object>>();            
    for (int i  = 0; i < src.Count; i++) {
        PdfReader reader = new PdfReader(src[i]);
        // merge the bookmarks
        IList<Dictionary<String, Object>> tmp = 
        SimpleBookmark.GetBookmark(reader);
        SimpleBookmark.ShiftPageNumbers(tmp, page_offset, null);
        foreach (var d in tmp) bookmarks.Add(d);
        // add the pages
        int n = reader.NumberOfPages;
        page_offset += n;
        for (int page = 0; page < n; ) {
            copy.AddPage(copy.GetImportedPage(reader, ++page));
        }
    }
    // Add the merged bookmarks
    copy.Outlines = bookmarks;
