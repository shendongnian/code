      private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            currentSize ++;
            RichTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, currentSize);
            Keyboard.Focus(RichTextBox);
            RichTextBox.Selection.Select(RichTextBox.Selection.Start, RichTextBox.Selection.End);
        }
