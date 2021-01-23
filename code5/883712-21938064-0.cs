        private TabPage RightClickedTab;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            RightClickedTab = tabControl1.SelectedTab;
            var pos = tabControl1.PointToClient(Cursor.Position);
            for (int tab = 0; tab < tabControl1.TabCount; ++tab) {
                if (tabControl1.GetTabRect(tab).Contains(pos)) {
                    RightClickedTab = tabControl1.TabPages[tab];
                    break;
                }
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            if (RightClickedTab != null) RightClickedTab.Dispose();
        }
