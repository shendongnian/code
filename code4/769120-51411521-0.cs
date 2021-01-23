        public static void HighlightWords(TextPointer text, string searchWord, string stringText)
        {
            int instancesOfSearchKey = Regex.Matches(stringText.ToLower(), searchWord.ToLower()).Count;
            for (int i = 0; i < instancesOfSearchKey; i++)
            {
                int lastInstanceIndex = HighlightNextInstance(text, searchWord);
                if (lastInstanceIndex == -1)
                {
                    break;
                }
                text = text.GetPositionAtOffset(lastInstanceIndex);
            }
        }
        private static int HighlightNextInstance(TextPointer text, string searchWord)
        {
            int indexOfLastInstance = -1;
            while (true)
            {
                TextPointer next = text.GetNextContextPosition(LogicalDirection.Forward);
                if (next == null)
                {
                    break;
                }
                TextRange newText = new TextRange(text, next);
                int index = newText.Text.ToLower().IndexOf(searchWord.ToLower());
                if (index != -1)
                {
                    indexOfLastInstance = index;
                }
                
                if (index > 0)
                {
                    TextPointer start = text.GetPositionAtOffset(index);
                    TextPointer end = text.GetPositionAtOffset(index + searchWord.Length);
                    TextRange textRange = new TextRange(start, end);
                    textRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                }
                text = next;
            }
            return indexOfLastInstance;
        }
