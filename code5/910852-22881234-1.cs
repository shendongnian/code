        public static double GetHorizontalScrollPos(RichTextBox box) {
            int index = box.SelectionStart;
            int line = box.GetLineFromCharIndex(index);
            int start = box.GetFirstCharIndexFromLine(line);
            Point pos = box.GetPositionFromCharIndex(start);
            return 100 * (1 - pos.X) / box.ClientSize.Width;
        }
