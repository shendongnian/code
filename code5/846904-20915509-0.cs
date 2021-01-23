    using (DocX document = DocX.Load(filename))
    {
    	var emptyLines = document.Paragraphs.Where(o => string.IsNullOrEmpty(o.Text));
    	foreach (var paragraph in emptyLines)
    	{
    		paragraph.Remove(false);
    	}
    	document.Save();
    }
