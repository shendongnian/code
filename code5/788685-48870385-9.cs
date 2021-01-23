    public static WordprocessingDocument CreateNew(this WordprocessingDocument org, string name)
    {
    	var doc = WordprocessingDocument.Create(name, WordprocessingDocumentType.Document);
    	doc.AddMainDocumentPart();
    	doc.MainDocumentPart.Document = new Document(new Body());
    	using (var streamReader = new StreamReader(org.MainDocumentPart.ThemePart.GetStream()))
    	using (var streamWriter = new StreamWriter(doc.MainDocumentPart.AddNewPart<ThemePart>().GetStream(FileMode.Create)))
    	{
    		streamWriter.Write(streamReader.ReadToEnd());
    	}
    	using (var streamReader = new StreamReader(org.MainDocumentPart.StyleDefinitionsPart.GetStream()))
    	using (var streamWriter = new StreamWriter(doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>().GetStream(FileMode.Create)))
    	{
    		streamWriter.Write(streamReader.ReadToEnd());
    	}
    	return doc;
    }
