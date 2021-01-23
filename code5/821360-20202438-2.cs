    public void ClearColumn(string colName){
      foreach(ListViewItem item in listView1.Items){
        var cell = item.SubItems[colName];
        if(cell != null) cell.Text = "";
      }
    }
