    for (TextPointer position = newDocument.ContentStart;
            position != null && position.CompareTo(newDocument.ContentEnd) <= 0;
            position = position.GetNextContextPosition(LogicalDirection.Forward))
    {
        if (position.CompareTo(newDocument.ContentEnd) == 0)
        {
            return newDocument;
        }
    
        String textRun = position.GetTextInRun(LogicalDirection.Forward);
        StringComparison stringComparison = StringComparison.CurrentCulture;
        Int32 indexInRun = textRun.IndexOf(search, stringComparison);
        if (indexInRun >= 0)
        {
            position = position.GetPositionAtOffset(indexInRun);
            if (position != null)
            {
                TextPointer nextPointer = position.GetPositionAtOffset(search.Length);
                TextRange textRange = new TextRange(position, nextPointer);
                textRange.ApplyPropertyValue(TextElement.BackgroundProperty, 
                              new SolidColorBrush(Colors.Yellow));
            }
        }
    }
