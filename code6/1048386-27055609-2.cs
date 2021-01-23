        public static void AppendLineAndAlignText(this RichTextBox richTextBox, string text, HorizontalAlignment alignment)
        {
            // This only works if "text" contains no newline characters.
            if (string.IsNullOrEmpty(text))
                return;
            richTextBox.AppendText("\n" + text);                       // Append a newline, and the text (which might also contain newlines).
            richTextBox.SelectionAlignment = alignment;                // Set the alignment of the selection.
        }
