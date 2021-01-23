    if (e.Button == MouseButtons.Right) {
      ContextMenuStrip cm = new ContextMenuStrip();
      cm.Items.Add("Data:" + e.RowIndex + e.ColumnIndex);
      dataGridView1.ContextMenuStrip = cm;
      dataGridView1.ContextMenuStrip.Show(MousePosition);
    }
