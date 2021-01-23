    public class TextBlockHighlightBehaviour : Behavior<TextBlock>
    {
        private EventHandler<DataTransferEventArgs> targetUpdatedHandler;
        public List<Highlight> Highlights { get; set; }
        public TextBlockHighlightBehaviour()
        {
            this.Highlights = new List<Highlight>();
        }
        #region Behaviour Overrides
        protected override void OnAttached()
        {
            base.OnAttached();
            targetUpdatedHandler = new EventHandler<DataTransferEventArgs>(TextBlockBindingUpdated);
            Binding.AddTargetUpdatedHandler(this.AssociatedObject, targetUpdatedHandler);
            // Run the initial behaviour logic
            HighlightTextBlock(this.AssociatedObject);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            Binding.RemoveTargetUpdatedHandler(this.AssociatedObject, targetUpdatedHandler);
        }
        #endregion
        #region Private Methods
        private void TextBlockBindingUpdated(object sender, DataTransferEventArgs e)
        {
            var textBlock = e.TargetObject as TextBlock;
            if (textBlock == null)
                return;
            if(e.Property.Name == "Text")
                HighlightTextBlock(textBlock);
        }
        private void HighlightTextBlock(TextBlock textBlock)
        {
            foreach (var highlight in this.Highlights)
            {
                foreach (var range in FindAllPhrases(textBlock, highlight.Text))
                {
                    if (highlight.Foreground != null)
                        range.ApplyPropertyValue(TextElement.ForegroundProperty, highlight.Foreground);
                    if(highlight.FontWeight != null)
                        range.ApplyPropertyValue(TextElement.FontWeightProperty, highlight.FontWeight);
                }
            }
        }
        private List<TextRange> FindAllPhrases(TextBlock textBlock, string phrase)
        {
            var result = new List<TextRange>();
            var position = textBlock.ContentStart;
            while (position != null)
            {
                var range = FindPhrase(position, phrase);
                if (range != null)
                {
                    result.Add(range);
                    position = range.End;
                }
                else
                    position = null;
            }
            return result;
        }
        // This method will search for a specified phrase (string) starting at a specified position.
        private TextRange FindPhrase(TextPointer position, string phrase)
        {
            while (position != null)
            {
                if (position.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = position.GetTextInRun(LogicalDirection.Forward);
                    // Find the starting index of any substring that matches "phrase".
                    int indexInRun = textRun.IndexOf(phrase);
                    if (indexInRun >= 0)
                    {
                        TextPointer start = position.GetPositionAtOffset(indexInRun);
                        TextPointer end = start.GetPositionAtOffset(phrase.Length);
                        return new TextRange(start, end);
                    }
                }
                position = position.GetNextContextPosition(LogicalDirection.Forward);
            }
            // position will be null if "phrase" is not found.
            return null;
        }
        #endregion
    }
    public class Highlight
    {
        public string Text { get; set; }
        public Brush Foreground { get; set; }
        public FontWeight FontWeight { get; set; }
    }
