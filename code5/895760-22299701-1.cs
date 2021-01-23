    public static class NavigationService
    {
        // Copied from http://geekswithblogs.net/casualjim/archive/2005/12/01/61722.aspx
        private static readonly Regex RE_URL = new Regex(@"(?#Protocol)(?:(?:ht|f)tp(?:s?)\:\/\/|~/|/)?(?#Username:Password)(?:\w+:\w+@)?(?#Subdomains)(?:(?:[-\w]+\.)+(?#TopLevel Domains)(?:com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum|travel|[a-z]{2}))(?#Port)(?::[\d]{1,5})?(?#Directories)(?:(?:(?:/(?:[-\w~!$+|.,=]|%[a-f\d]{2})+)+|/)+|\?|#)?(?#Query)(?:(?:\?(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)(?:&(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)*)*(?#Anchor)(?:#(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)?");
    
        public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
            "Text",
            typeof(string),
            typeof(NavigationService),
            new PropertyMetadata(null, OnTextChanged)
        );
    
        public static string GetText(DependencyObject d) { return d.GetValue(TextProperty) as string; }
    
        public static void SetText(DependencyObject d, string value) { d.SetValue(TextProperty, value); }
    
        static Paragraph paragraph = new Paragraph();
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var text_block = d as RichTextBox;
            if (text_block == null)
                return;
    
            text_block.Blocks.Clear();
    
            var new_text = (string)e.NewValue;
            if (string.IsNullOrEmpty(new_text))
                return;
    
            // Find all URLs using a regular expression
            int last_pos = 0;
            foreach (Match match in RE_URL.Matches(new_text))
            {
                // Copy raw string from the last position up to the match
                if (match.Index != last_pos)
                {
                    var raw_text = new_text.Substring(last_pos, match.Index - last_pos);
                    //text_block.Inlines.Add(new Run(raw_text));
                    //var paragraph1 = new Paragraph();
                    paragraph.Inlines.Add(new Run { Text = raw_text });
                    if (text_block.Blocks.Contains(paragraph))
                    {
                        text_block.Blocks.Add(paragraph);
                    }
                }
    
                // Create a hyperlink for the match
                var link = new HyperlinkButton()
                {
                    Content = match.Value,
                    NavigateUri = new Uri(match.Value),
                    Margin = new Thickness(-20, 0, -20, -15),
                    FontSize = 20,
                    TargetName = "_blank"
                };
                link.Click += OnUrlClick;
    
    
                var inlineUi = new InlineUIContainer();
                inlineUi.Child = link;
                if (!paragraph.Inlines.Contains(inlineUi))
                {
                    paragraph.Inlines.Add(inlineUi);
                }
                if (text_block.Blocks.Contains(paragraph))
                {
                    text_block.Blocks.Add(paragraph);
                }
    
                //text_block.Inlines.Add(link);
    
                // Update the last matched position
                last_pos = match.Index + match.Length;
            }
    
            // Finally, copy the remainder of the string
            if (last_pos < new_text.Length)
            {
                //var paragraph = new Paragraph();
                paragraph.Inlines.Add(new Run { Text = new_text.Substring(last_pos) });
                text_block.Blocks.Add(paragraph);
            }
        }
    
        private static void OnUrlClick(object sender, RoutedEventArgs e)
        {
            var link = (HyperlinkButton)sender;
            // Do something with link.NavigateUri otherwise by default it would be open in IE.
        }
    }
    <RichTextBox local:NavigationService.Text="{Binding Review}" IsReadOnly="True" />
