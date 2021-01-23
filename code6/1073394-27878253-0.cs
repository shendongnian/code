        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.ActiveDocument.Revisions.Count > 0)
            {
                List<Revision> revisions = new List<Revision>();
                foreach (Revision rev in Application.ActiveDocument.Revisions)
                {
                    revisions.Add(rev);
                }
                frmAcceptRevisions accept = new frmAcceptRevisions(revisions);
                accept.ShowDialog();
            }
        }
