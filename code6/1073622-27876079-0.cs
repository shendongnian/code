    public static class FlowDocumentExtensions
        {
            public static void ScrollToWord(
                this FlowDocument flowDocument,
                ScrollViewer scrollViewer,
                string word)
            {
                var currentText = flowDocument.ContentStart;
    
                while (true)
                {
                    TextPointer nextText = 
                           currentText.GetNextContextPosition(
                              LogicalDirection.Forward);
                    if (nextText == null)
                        return;
    
                    TextRange txt = new TextRange(currentText, nextText);
    
                    int index = txt.Text.IndexOf(word, StringComparison.Ordinal);
                    if (index > 0)
                    {
                        TextPointer start = currentText.GetPositionAtOffset(index);
    
                        if (start != null)
                        {
                            var rect = start.GetCharacterRect(
                               LogicalDirection.Forward);
                            scrollViewer.ScrollToVerticalOffset(rect.Y);
                        }
    
                        return;
                    }
    
                    currentText = nextText;
                }
            }
        }
