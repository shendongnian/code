    var hitTestInfo = dataGridView1.HitTest(e.X, e.Y);
    if (hitTestInfo.Type != DataGridViewHitTestType.Cell) { return; }
    var mi = new MenuItem("Copy")
    mi.Tag = hitTestInfo;
    mi.Click += (s, e) =>
    {
        var hti = ((MenuItem)s).Tag as HitTestInfo;
        var val = dataGridView1.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Value;
        Clipboard.SetData(DataFormats.Text, val);
    }
    m.MenuItems.Add(mi);
