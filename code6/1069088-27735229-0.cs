        public static Span returnTextWithUrl(String text)
        {
            if(text == null) { return null;  }
            var span = new Span();
            MatchCollection mactches = uriFindRegex.Matches(text);
            int lastIndex = 0;
            foreach (Match match in mactches)
            {
                var run = new Run(text.Substring(lastIndex, match.Index - lastIndex));
                span.Inlines.Add(run);
                lastIndex = match.Index + match.Length;
                var hyperlink = new Hyperlink();
                hyperlink.Content = match.Value;
                hyperlink.NavigateUri = new Uri(match.Value);
                span.Inlines.Add(hyperlink);
            }
            span.Inlines.Add(new Run(text.Substring(lastIndex)));
            return span;
        }
