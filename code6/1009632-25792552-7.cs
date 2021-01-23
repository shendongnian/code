    public static class TextBlockInlineBinder
    {
        #region Static DependencyProperty Implementation
        public static readonly DependencyProperty InlinesProperty =
            DependencyProperty.RegisterAttached("Inlines",
            typeof(IEnumerable<Inline>),
            typeof(TextBlockInlineBinder),
            new UIPropertyMetadata(new Inline[0], InlinesChanged));
        public static string GetInlines(DependencyObject obj)
        {
            return (string)obj.GetValue(InlinesProperty);
        }
        public static void SetInlines(DependencyObject obj, string value)
        {
            obj.SetValue(InlinesProperty, value);
        }
        #endregion
        private static void InlinesChanged(DependencyObject sender, 
                                           DependencyPropertyChangedEventArgs e)
        {
            var value = e.NewValue as IEnumerable<Inline>;
            var textBlock = sender as TextBlock;
            textBlock.Inlines.Clear();
            textBlock.Inlines.AddRange(value);
        }
    } 
