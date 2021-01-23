    public void ClearColumn(string colText){
      if(listView1.Items.Count == 0) return;
      var col =  listView1.Columns.Cast<ColumnHeader>()
                          .Select((x,i)=>new{x,i})
                          .FirstOrDefault(a=>a.x.Text == colText);
      if(col == null) return;
      foreach(ListViewItem item in listView1.Items){
        var cell = item.SubItems[col.i];
        if(cell != null) cell.Text = "";
      }
    }
