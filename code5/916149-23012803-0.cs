     private void _btnFormat_Click(object sender, RoutedEventArgs e)
        {
            TextRange rangeOfText = new TextRange(richTextBoxArticleBody.Document.ContentStart, richTextBoxArticleBody.Document.ContentEnd);
            rangeOfText.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            rangeOfText.ApplyPropertyValue(TextElement.FontSizeProperty, "12");
            rangeOfText.ApplyPropertyValue(TextElement.FontFamilyProperty, "Arial");
            rangeOfText.ApplyPropertyValue(TextElement.FontStyleProperty, "Normal");
            rangeOfText.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            rangeOfText.ApplyPropertyValue(Paragraph.MarginProperty, new Thickness(0));
        }
