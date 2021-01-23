     void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Copy" && dataGridView1.CurrentCell.Value != null)
            {
                Clipboard.SetDataObject(dataGridView1.CurrentCell.Value.ToString(), false);
            }
        }
     void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip = contextMenu;
                dataGridView1.CurrentCell = myDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
