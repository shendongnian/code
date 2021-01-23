    public static class Helper
    {
        public static string GetWordUnderCursor(RichTextBox control, MouseEventArgs e)
        {
            //check if there's any text entered
            if (string.IsNullOrWhiteSpace(control.Text))
                return null;
            //get index of nearest character
            var index = control.GetCharIndexFromPosition(e.Location);
            //check if mouse is above a word (non-whitespace character)
            if (char.IsWhiteSpace(control.Text[index]))
                return null;
            //find the start index of the word
            var start = index;
            while (start > 0 && !char.IsWhiteSpace(control.Text[start - 1]))
                start--;
            //find the end index of the word
            var end = index;
            while (end < control.Text.Length - 1 && !char.IsWhiteSpace(control.Text[end + 1]))
                end++;
            //get and return the whole word
            return control.Text.Substring(start, end - start + 1);
        }
    }
