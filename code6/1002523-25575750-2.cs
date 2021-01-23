        void SpecialTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            var range = new TextRange(Document.ContentStart, Document.ContentEnd);
            if (range.IsEmpty)
            {
                AppendText("Initial Text...");
            }
        }
