    class LineColorizer : DocumentColorizingTransformer
    {
        int lineNumber;
        
        public LineColorizer(int lineNumber)
        {
            this.lineNumber = lineNumber;
        }
        
        protected override void ColorizeLine(ICSharpCode.AvalonEdit.Document.DocumentLine line)
        {
            if (!line.IsDeleted && line.LineNumber == lineNumber) {
                ChangeLinePart(line.Offset, line.EndOffset, ApplyChanges);
            }
        }
        
        void ApplyChanges(VisualLineElement element)
        {
            // This is where you do anything with the line
            element.TextRunProperties.SetForegroundBrush(Brushes.Red);
        }
    }
