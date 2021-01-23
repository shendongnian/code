	/// <summary>
	/// Read bookmark text/names in word document
	/// </summary>
	/// <param name="filePath"></param>
	/// <remarks>
	/// Uses free DocX by Xceed
	/// </remarks>
	public void ReadBookmarks(string filePath)
	{
		//Load document
		using (DocX Document = DocX.Load(filePath))
		{
			//This is slow in free version (v1.3 Docx), is fixed in v1.4Docx (free version is slower to get this)
			BookmarkCollection bookmarks = Document.Bookmarks;
			//Iterate over bookmarks in document
			foreach (Bookmark bookmark in bookmarks) {
				//Name of bookmark
				string bookmarkName = bookmark.Name;
				//Text of bookmark, usually a word heading (1, 2, 3...)
				string bookmarkText = bookmark.Paragraph.Text;
			}
		}
	}
