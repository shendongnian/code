        /// <summary>
        /// Appends a HyperlinkButton with
        /// the given text and navigate uri to the given RichTextBlock.
        /// </summary>
        /// <param name="richTextBlock">The rich text block.</param>
        /// <param name="text">The text.</param>
        /// <param name="uri">The URI.</param>
        public static void AppendLink(this RichTextBlock richTextBlock, string text, Uri uri)
        {
            Paragraph paragraph;
            if (richTextBlock.Blocks.Count == 0 ||
                (paragraph = richTextBlock.Blocks[richTextBlock.Blocks.Count - 1] as Paragraph) == null)
            {
                paragraph = new Paragraph();
                richTextBlock.Blocks.Add(paragraph);
            }
            var link =
                new HyperlinkButton
                {
                    Content = text,
                    NavigateUri = uri
                };
            paragraph.Inlines.Add(new InlineUIContainer { Child = link });
        }
