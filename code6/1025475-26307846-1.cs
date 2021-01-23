    using (WordprocessingDocument doc =
                    WordprocessingDocument.Open(@"yourpath\testdocument.docx", true))
            {
                var body = doc.MainDocumentPart.Document.Body;
                var paras = body.Elements<Paragraph>();
                foreach (var para in paras)
                {
                    foreach (var run in para.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            if (text.Text.Contains("text-to-replace"))
                            {
                                text.Text = text.Text.Replace("text-to-replace", "");
				run.AppendChild(new Break());
                            }
                        }
                    }
                }
            }
