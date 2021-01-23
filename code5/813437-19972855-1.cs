    void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {      
       lastSortedAscending = !lastSortedAscending;
       if ( lastSortedAscending) 
          { 
           dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name],ListSortDirection.Descending); 
          }
       else
         {
           dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name],ListSortDirection.Ascending); 
         }
    }
