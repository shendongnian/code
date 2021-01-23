    private static void OnElementsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ExtendedRichTextBlock sender = d as ExtendedRichTextBlock;
        if (sender != null)
        {
            sender.Content.Blocks.Clear();
            var x = e.NewValue as IList<string>;
                    
            if (x != null)
            {
                foreach (var item in x)
                {
                    var p = new Paragraph();
                    p.Inlines.Add(new Run { Text = item });    // WinRT information: Element is already the child of another element.
                    sender.Content.Blocks.Add(p);
                }
            }
        }
    }
