    static Converters.WhiteSpaceConverter conv = new Converters.WhiteSpaceConverter();
    private void TextBox_Copy_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        TextBox tb = sender as TextBox;
        
        if (tb != null)
            Clipboard.SetText((string)conv.ConvertBack(tb.SelectedText, typeof(TextBox), null, System.Globalization.CultureInfo.CurrentCulture));
    }
    
