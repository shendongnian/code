     private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
     {
        var textBlock = sender as TextBlock;
        if (textBlock != null)
        {
            var test = ((BitmapImage)((ImageBrush)textBlock.Tag).ImageSource).UriSource.OriginalString;
        }
     }
