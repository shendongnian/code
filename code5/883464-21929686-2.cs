        private void toolStripLabel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                AutoCloseDropDowns(menuStrip1.Items, false);
                contextMenuStrip1.Show(Cursor.Position);
                AutoCloseDropDowns(menuStrip1.Items, true);
            }
        }
        private void AutoCloseDropDowns(ToolStripItemCollection items, bool autoClose)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    var ts = item as ToolStripDropDownItem;
                    if (ts != null)
                    {
                        ts.DropDown.AutoClose = autoClose;
                        AutoCloseDropDowns(ts.DropDownItems, autoClose);
                    }
                }
            }
        }
