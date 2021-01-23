    private void CleanClipboardText()
        {
            string cleaned = Clipboard.GetText(TextDataFormat.Rtf);
            if (cleaned != null)
            {
                Regex regex = new Regex(@"\\cellx\d{4}?");
                cleaned = regex.Replace(cleaned, " ");
                regex = new Regex(@"\\cell");
                cleaned = regex.Replace(cleaned, " ");
                Clipboard.SetText(cleaned, TextDataFormat.Rtf);
            }
        }
