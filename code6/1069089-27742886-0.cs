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
                    Regex regx = new Regex(@"(http://[^\s]+)", RegexOptions.IgnoreCase);
                    var str = regx.Split(text);
                    for (int i = 0; i < str.Length; i++)
                        if (i % 2 == 0)
                            textBl.Inlines.Add(new Run { Text = str[i] });
                        else
                        {
                            Hyperlink link = new Hyperlink { NavigateUri = new Uri(str[i]), Foreground = Application.Current.Resources["PhoneAccentBrush"] as SolidColorBrush };
                            link.Inlines.Add(new Run { Text = str[i] });
                            textBl.Inlines.Add(link);
                        }                        
                }
            }));
    }
