    public static class TextBlockExtension
    {
        public static string GetFormattedText(DependencyObject obj)
        { return (string)obj.GetValue(FormattedTextProperty); }
        public static void SetFormattedText(DependencyObject obj, string value)
        { obj.SetValue(FormattedTextProperty, value); }
        public static readonly DependencyProperty FormattedTextProperty =
            DependencyProperty.Register("FormattedText", typeof(string), typeof(TextBlockExtension),
            new PropertyMetadata(string.Empty, (sender, e) =>
            {
                string text = e.NewValue as string;
                var textBl = sender as TextBlock;
                if (textBl != null)
                {
                    textBl.Inlines.Clear();
                    var str = text.Split(new string[] { "<b>", "</b>" }, StringSplitOptions.None);
                    for (int i = 0; i < str.Length; i++)
                        textBl.Inlines.Add(new Run { Text = str[i], FontWeight = i % 2 == 1 ? FontWeights.Bold : FontWeights.Normal });
                }
            }));
    }
