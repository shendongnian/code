    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(athleteFile, false))
    {
        foreach (BookmarkStart bookmark in wordDocument.MainDocumentPart.Document.Body.Descendants<BookmarkStart>())
        {       
            // Get name of bookmark
			string bookmarkNameOriginal = bookmark.Name;
			// Get bookmark text from parent elements text
			string bookmarkText = bookmark.Parent.InnerText;
        }
    }
