        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Paragraph p in myRichTextBox.Document.Blocks)
            {
                foreach (var inline in p.Inlines)
                {
                    if (inline is Bold)
                    {
                        // ...
                    }
                    if (inline is Italic)
                    {
                        // ...
                    }
                    if (inline is Underline)
                    {
                        // ...
                    }
                }
            }
        }
