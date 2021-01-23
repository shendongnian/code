                List<UIElement> labels = new List<UIElement>();
    
                foreach (var block in myRTB.Document.Blocks)
                {
                    if (block is Paragraph)
                    {
                        var paragraph = block as Paragraph;
                        foreach (var inline in paragraph.Inlines)
                        {
                            if(inline is InlineUIContainer)
                            {
                                labels.Add(((InlineUIContainer)inline).Child);
                            }
                        }
                       
                    }
                }
