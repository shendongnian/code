	var bookmarks = new ArrayList();
	var rdr = new PdfReader(first);
	var doc = new Document(rdr.GetPageSizeWithRotation(1));
	var wri = new PdfCopy(doc, memorystream);
	var temp = wri.GetImportedPage(rdr, 1); // get 1st page
	var h = temp.Height; // get height of 1st page
	// Add first item to bookmarks.
	var test = new Hashtable();
	test.Add("Action", "GoTo");
	test.Add("Title", "Page1 0 H 0");
	test.Add("Page", "1 XYZ 0 "+h+" 0"); // use height of 1st page
	bookmarks.Add(test);
	// Do your worst and afterwards set the bookmarks to Outline. So yeah.
	wri.Outlines = bookmarks;
