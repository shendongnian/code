    List<FolderItem> items = new List<FolderItem>();
    private void dgvFiles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
        if(e.ColumnIndex == 1) {
            items.OrderBy(i => i.type).ThenBy(i => i.oldName);
            items.Reverse(); // to account for ascending/descending order
            RefreshDataGridView();
        }
    }
    public void RefreshDataGridView() {
        dgvFiles.Rows.Clear();
        foreach(FolderItem item in items) {
            dgvFiles.Rows.Add(item.icon, item.oldName, item.newName, item.type, item.size, item.created, item.modified);
        }
    }
