    MyGrid.BeginUpdate();
            
    for (int i = 0; i < MyGrid.RowCount; i++)
    {
        if (MyGrid.IsRowSelected(i))
            MyGrid.UnselectRow(i);
    }
    MyGrid.EndUpdate();
