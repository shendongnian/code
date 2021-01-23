    var picture = source.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Drawing.Pictures.Picture>().FirstOrDefault();
    var blip = picture.Descendants().Where(d => d.GetAttributes()
    		.Any(a => a.LocalName == "embed" && !string.IsNullOrEmpty(a.Value))
    		).FirstOrDefault();
    
    var attr = blip.GetAttributes().FirstOrDefault(a => a.LocalName == "embed");
    var newRel = opgaveDocument.CopyImage(attr.Value, mainDoc);
    attr.Value = newRel;
    blip.SetAttribute(attr);
