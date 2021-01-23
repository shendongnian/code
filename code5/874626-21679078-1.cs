        using (WordprocessingDocument doc =
                     WordprocessingDocument.Open(sourceFile, true))
        {
            foreach (var cc in doc.ContentControls())
            {
                SdtProperties props = cc.Elements<SdtProperties>().FirstOrDefault();
                Tag tag = props.Elements<Tag>().FirstOrDefault();
                SdtContentText text = props.Elements<SdtContentText>().FirstOrDefault();
                if (text == null)
                {
                    text = new SdtContentText();
                    text.MultiLine = new OnOffValue(true);
                    cc.AppendChild<SdtContentText>(text);
                }
                if (tag != null)
                    Console.WriteLine(tag.Val);
            }
            doc.MainDocumentPart.Document.Save();
        }
