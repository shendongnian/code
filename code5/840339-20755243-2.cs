    using (WordprocessingDocument doc = WordprocessingDocument.Open("word-wrP.docx", true))
            {
                Body body = doc.MainDocumentPart.Document.Body;
                //Documents' numbering definition
                Numbering num = doc.MainDocumentPart.NumberingDefinitionsPart.Numbering;
                //Get all paragraphs in the document
                IEnumerable<Paragraph> paragraphs = doc.MainDocumentPart.Document.Body.OfType<Paragraph>();
                foreach (Paragraph paragraph in paragraphs)
                {
                    int tempLevel = 0; 
                 
                    //Each paragraph has a reference to a numbering definition that is defined by the numbering ID
                    NumberingId numId = paragraph.ParagraphProperties.NumberingProperties.NumberingId;
                    //NumberingLevelReference defines the outline level or the "indent" of Numbering, index starts at Zero.
                    NumberingLevelReference iLevel =
                        paragraph.ParagraphProperties.NumberingProperties.NumberingLevelReference;
                    //From the numbering reference we get the actual numbering definition to get start value of the outline etc etc.
                    var firstOrDefault =
                        num.Descendants<NumberingInstance>().FirstOrDefault(tag => tag.NumberID == (int)numId.Val);
                    if (firstOrDefault != null)
                    {
                        var absNumId =
                            firstOrDefault.GetFirstChild<AbstractNumId>();
                        AbstractNum absNum =
                            num.OfType<AbstractNum>().FirstOrDefault(tag => tag.AbstractNumberId == (int)absNumId.Val);
                        if (absNum != null)
                        {
                            StartNumberingValue start = absNum.OfType<StartNumberingValue>().FirstOrDefault();
                            // once you have the start value its just a matter of counting the paragraphs that have the same numberingId and from the Number
                            //ingLevel you can calculate the actual values that correspond to each paragraph.
                            if (start != null) startValue = start.Val;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed!");
                    }
                }
            }
