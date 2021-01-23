    private MyModelType _ContextModel;
    void treeListView1_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e) {
        _ContextModel = e.Model as MyModelType;
        contextMenuStrip1.Show(Cursor.Position);
    }
