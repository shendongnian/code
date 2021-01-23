        private void highlightText()
        {
            Selection selection = GetSelection(mRtbxOperations.Text);
            if (selection == null)
                return;
            mRtbxOperations.SelectionStart = selection.Start;
            mRtbxOperations.SelectionLength = selection.Length;
            mRtbxOperations.SelectionBackColor = Color.LightBlue;
            mRtbxOperations.SelectionFont = new Font(mRtbxOperations.SelectionFont,   
                FontStyle.Underline);
        }
        private static Selection GetSelection(string text)
        {
            int startIndex = text.IndexOf(@"{", 0);
            if (startIndex == -1)
                return null;
            int endIndex = text.IndexOf(@"}", startIndex);
            if (endIndex == -1)
                return null;
            return new Selection(startIndex + 1, endIndex);
        }
        public class Selection
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Length
            {
                get
                {
                    return End - Start;
                }
            }
            public Selection(int startIndex, int endIndex)
            {
                this.Start = startIndex;
                this.End = endIndex;
            }
        }
