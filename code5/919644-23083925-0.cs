        private void _btnFormat_Click(object sender, RoutedEventArgs e)
        {              
           TextRange rangeOfText = new TextRange(richTextBoxArticleBody.Document.ContentStart, richTextBoxArticleBody.Document.ContentEnd);
          rangeOfText.ApplyPropertyValue(Table.BorderThicknessProperty, "3");
          rangeOfText.ApplyPropertyValue(Table.BorderBrushProperty, Brushes.Red);
         }
