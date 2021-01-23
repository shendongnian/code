    public List<string> GetTagsFromNewTemplate(string filePath)
            {
                var tags = new HashSet<string>();
    
                using (WordprocessingDocument myDocument = WordprocessingDocument.Open(filePath, false))
                {
                    var textbox = myDocument.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Tag>().Select(x => x.Val);
                    textbox.ForEach(x => tags.Add(x));
                }
                return tags.Distinct().ToList();
            } 
