        private void lvMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewItem lvi = lvMain.GetItemAt(e.X, e.Y);
                if (lvi == null)
                {
                    // Workaround for 1px space between items
                    lvi = lvMain.GetItemAt(e.X, e.Y - 1);
                    if (lvi != null)
                    {
                        lvi.Selected = true;
                    }
                }
            }
        }
