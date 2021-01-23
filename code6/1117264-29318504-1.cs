      IEnumerable<TextRange> wordRanges = GetAllWordRanges(RichTextBox.Document);
            foreach (TextRange wordRange in wordRanges)
            {
                if (wordRange.Text == "keyword")
                {
                    wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                }
            }
