    //Resize event handler for your Form1
    private void Form1_Resize(object sender, EventArgs e){
        column2.Width = -2;
    }
    //ColumnWidthChanged event handler
    private void listView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e){
        int lastIndex = listView1.Columns.Count - 1;
        if (e.ColumnIndex != lastIndex) listView1.Columns[lastIndex].Width = -2;
    }
    //ColumnWidthChanging event handler
    private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e){
        int lastIndex = listView1.Columns.Count - 1;
        if (e.ColumnIndex != lastIndex) listView1.Columns[lastIndex].Width = -2;
    }
