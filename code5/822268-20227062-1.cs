    TextPointer position = box1.Document.ContentStart;
    while (position != null)
    {
        if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
        {
            TextPointer start = position.GetPositionAtOffset(0, LogicalDirection.Forward);
            TextPointer end = position.GetPositionAtOffset(1, LogicalDirection.Backward);
            new TextRange(start, end).ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            break;
        }
        position = position.GetNextContextPosition(LogicalDirection.Forward);
    }
