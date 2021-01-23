    public void ClearColumn(string columnHeaderName){
      int i = listView1.Columns.IndexOfKey(columnHeaderName);
      if(i == -1) return;
      foreach(ListViewItem item in listView1.Items){
        item.SubItems[i].Text = "";
      }
    }
