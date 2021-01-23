        private void commentBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtSQL.Selection.Text.Length > 0)
            {
                Range range = txtSQL.Selection.Range;
                int f = range.StartingLine.Number;
                int t = range.EndingLine.Number;
                for (int i = f; i <= t; i++)
                {
                    txtSQL.InsertText(txtSQL.Lines[i].StartPosition,"--");
                }
                txtSQL.Selection.Start = txtSQL.Lines[f].StartPosition;
                txtSQL.Selection.End = txtSQL.Lines[t].EndPosition;
            }
        }
