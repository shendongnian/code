        public static double GetVerticalScrollPos(RichTextBox box) {
            int index = box.GetCharIndexFromPosition(new Point(1, 1));
            int topline = box.GetLineFromCharIndex(index);
            int lines = box.Lines.Length;
            return lines == 0 ? 0 : 100.0 * topline / lines; 
        }
