        public static void AppendLineAndAlignText(this RichTextBox richTextBox, string text, HorizontalAlignment alignment)
        {
            if (string.IsNullOrEmpty(text))
                return;
            var index = richTextBox.Lines.Length;                      // Get the initial number of lines.
            richTextBox.AppendText("\n" + text);                       // Append a newline, and the text (which might also contain newlines).
            var start = richTextBox.GetFirstCharIndexFromLine(index);  // Get the 1st char index of the appended text
            var length = richTextBox.Text.Length;     
            richTextBox.Select(start, length - index);                 // Select from there to the end
            richTextBox.SelectionAlignment = alignment;                // Set the alignment of the selection.
            richTextBox.DeselectAll();
        }
