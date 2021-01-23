    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var paragraph = new Paragraph();
        paragraph.Inlines.Add(new Run(string.Format("Paragraph Sample {0}", Environment.TickCount)));
        RichTextBox1.Document.Blocks.Add(paragraph);
        RichTextBox1.Focus();
        RichTextBox1.ScrollToEnd();
    }
