        /// <summary>
        /// Append formatted text to a Rich Text Box control 
        /// </summary>
        /// <param name="rtb">Rich Text Box to which horizontal bar is to be added</param>
        /// <param name="text">Text to be appended to Rich Text Box</param>
        /// <param name="textColour">Colour of text to be appended</param>
        /// <param name="isBold">Flag indicating whether appended text is bold</param>
        /// <param name="alignment">Horizontal alignment of appended text</param>
        private void AppendFormattedText(RichTextBox rtb, string text, Color textColour, Boolean isBold, HorizontalAlignment alignment)
        {
            int start = txtActivityLog.TextLength;
            txtActivityLog.AppendText(text);
            int end = txtActivityLog.TextLength; // now longer by length of appended text
            // Select text that was appended
            txtActivityLog.Select(start, end - start);
            #region Apply Formatting
            txtActivityLog.SelectionColor = textColour;
            txtActivityLog.SelectionAlignment = alignment;
            txtActivityLog.SelectionFont = new Font(
                 txtActivityLog.SelectionFont.FontFamily,
                 txtActivityLog.SelectionFont.Size,
                 (isBold ? FontStyle.Bold : FontStyle.Regular));
            #endregion
            // Unselect text
            txtActivityLog.SelectionLength = 0;
        }
