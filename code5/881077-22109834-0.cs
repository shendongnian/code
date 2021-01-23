    DataGridViewColumn column = dataGridView1.SortedColumn;
    ListSortDirection order;
    if (dataGridView1.SortOrder.Equals(SortOrder.Ascending))
       {
           order = ListSortDirection.Ascending;
       }
    else
       {
           order = ListSortDirection.Descending;
       }
    dataGridView1.Sort(column, order);
