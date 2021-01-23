    TextBlock.Inlines.ElementAt(mItemIndex).Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dictionaryItem.Value._applyColor.ToString()));
    
    TextBlock.Inlines.ElementAt(mItemIndex).FontFamily = new FontFamily(ftItem.Value._applyFontFamily.ToString());
    
    TextBlock.Inlines.ElementAt(mItemIndex).FontStyle = FontStyles.Italic;
    
    TextBlock.Inlines.ElementAt(mItemIndex).TextDecorations = TextDecorations.Underline;
    
    TextBlock.Inlines.ElementAt(mItemIndex).TextDecorations = TextDecorations.Strikethrough;
