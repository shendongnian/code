                InlineUIContainer inlineContainer = containers[0] ;    
                foreach (var block in myRTB.Document.Blocks)
                {
                    if (block is Paragraph)
                    {
                        var paragraph = block as Paragraph;
    
                        if (paragraph.Inlines.Contains(inlineContainer))
                        {
                            paragraph.Inlines.Remove(inlineContainer);
                        }
                    }
                }
