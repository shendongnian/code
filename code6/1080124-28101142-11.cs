    // We can build the document section by section
    var documentText = new StringBuilder();
    foreach (var section in sections)
    {
        // Here we can display headers and paragraphs in a custom way.
        // For example, we can separate all sections with a blank line:
        documentText.AppendLine();
        // If there is a header, we can underline it
        if (!string.IsNullOrWhiteSpace(section.Header))
        {
            documentText.AppendLine(section.Header);
            documentText.AppendLine(new string('-', section.Header.Length));
        }
        // We can mark each paragraph with an arrow (--> )
        foreach (var paragraph in section.Paragraphs)
        {
            documentText.Append("--> ");
            // And write out each sentence, separated by a space
            documentText.AppendLine(string.Join(" ", paragraph.Sentences));
        }
    }
    
    richTextBox1.Font = new Font(FontFamily.GenericMonospace, 12);
    richTextBox1.Text = documentText.ToString();
