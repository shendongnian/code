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
            int sIndex = text.LastIndexOf(@"{");
            if (sIndex == -1)
                return null;
            int eIndex = text.IndexOf(@"}", sIndex);
            if (eIndex == -1)
                return null;
            return new Selection(sIndex + 1, eIndex);
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
