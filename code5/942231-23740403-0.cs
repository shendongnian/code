        private void TaggableTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged -= TaggableTextBox_TextChanged;
            
            ReprocessTags();
        }
        private void ReprocessTags()
        {
            //Remove all tags, and re-process
            RemoveAllTags();
            ProcessTags();
        }
        private void RemoveAllTags()
        {
            var textRange = new TextRange(Document.ContentStart, Document.ContentEnd);
            textRange.ClearAllProperties();
        }
        private void ProcessTags()
        {
            if (Tags == null) 
                return;
            foreach (var tag in Tags.ToArray())
            {
                TagRegion(tag.Start, tag.Length, tag.Type);
            }
        }
        private void TagRegion(int index, int length, TagType type)
        {
            var start = GoToPoint(Document.ContentStart, index);
            var end = GoToPoint(start, length);
            TagSelection(type, start, end);
        }
