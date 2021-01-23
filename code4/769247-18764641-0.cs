    public static void SetNotes(this WordprocessingDocument doc, string value)
    {
    	MainDocumentPart main = doc.MainDocumentPart;
    	string altChunkId = "AltChunkId" + Guid.NewGuid().ToString().Replace("-", "");
    	var chunk = main.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.TextPlain, altChunkId);
    
    	using (var mStream = new MemoryStream())
    	{
    		using (var writer = new StreamWriter(mStream))
    		{
    			writer.Write(value);
    			writer.Flush();
    			mStream.Position = 0;
    			chunk.FeedData(mStream);
    		}
    	}
    
    	var altChunk = new AltChunk();
    	altChunk.Id = altChunkId;
    
    	OpenXmlElement afterThat = null;
    	foreach (var para in main.Document.Body.Descendants<Paragraph>())
    	{
    		if (para.InnerText.Equals("Notes:"))
    		{
    			afterThat = para;
    		}
    	}
    	main.Document.Body.InsertAfter(altChunk, afterThat);
    }
