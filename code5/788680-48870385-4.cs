    private static void CopyDocumentWithImages(string path)
    {
    	if (!Path.GetFileName(path).StartsWith("~$"))
    	{
    		using (var source = WordprocessingDocument.Open(path, false))
    		{
    			using (var newDoc = source.CreateNew(path.Replace(".docx", "-images.docx")))
    			{
    				foreach (var e in source.MainDocumentPart.Document.Body.Elements())
    				{
    					var clonedElement = e.CloneNode(true);
    					clonedElement.Descendants<DocumentFormat.OpenXml.Drawing.Blip>()
    						.ToList().ForEach(blip =>
    						{
    							var newRelation = newDoc.CopyImage(blip.Embed, source);
    							blip.Embed = newRelation;
    						});
    					clonedElement.Descendants<DocumentFormat.OpenXml.Vml.ImageData>().ToList().ForEach(imageData =>
    					{
    						var newRelation = newDoc.CopyImage(imageData.RelationshipId, source);
    						imageData.RelationshipId = newRelation;
    					});
    					newDoc.MainDocumentPart.Document.Append(clonedElement);
    				}
    				newDoc.Save();
    			}
    		}
    	}
    }
