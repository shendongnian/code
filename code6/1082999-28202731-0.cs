        private void txtPattern_MouseDown(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int i = GetMouseToCursorIndex(txtPattern, e.Location);
                Point p = AreWeInATag(txtPattern.Text, i);
                txtPattern.SelectionStart = p.X;
                txtPattern.SelectionLength = p.Y - p.X;
            }
        }
        private int GetMouseToCursorIndex(TextBox ptxtThis, Point pptLocal)
        {
            int i = ptxtThis.GetCharIndexFromPosition(pptLocal);
            int iLength = ptxtThis.Text.Length;
            if (i == iLength - 1)
            {
                //see if user is past
                int iXLastChar = ptxtThis.GetPositionFromCharIndex(i).X;
                int iAvgX = iXLastChar / ptxtThis.Text.Length;
                if (pptLocal.X > iXLastChar + iAvgX)
                {
                    i = i + 1;
                }
            }
            return i;
        }
        private Point AreWeInATag(string psSource, int piIndex)
        {
            //Are we in a tag?
            int i = piIndex;
            int iStart = i;
            int iEnd = i;
            //Check the position of the tags
            string sBefore = psSource.Substring(0, i);
            int iStartTag = sBefore.LastIndexOf("<");
            int iEndTag = sBefore.LastIndexOf(">");
            //Is there an open start tag before
            if (iStartTag > iEndTag)
            {
                iStart = iStartTag;
                //now check if there is an end tag after the insertion point
                iStartTag = psSource.Substring(i, psSource.Length - i).IndexOf("<");
                iEndTag = psSource.Substring(i, psSource.Length - i).IndexOf(">");
                if (iEndTag != -1 && (iEndTag < iStartTag || iStartTag == -1))
                {
                    iEnd = iEndTag + i + 1;
                }
            }
            return new Point(iStart, iEnd);
        }
