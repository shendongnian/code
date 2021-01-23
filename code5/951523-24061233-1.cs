        private void lvMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (lvMain.SelectedItems.Count == 0 && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                ListViewItem lvi = lvMain.GetItemAt(e.X, e.Y);
                if (lvi == null)
                {
                    // Workaround for 1px space between items
                    lvi = lvMain.GetItemAt(e.X, e.Y - 1);
                }
                if (lvi != null)
                {
                    lvi.Selected = true;
                }
            }
        }
