    void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {      
    if (dataGridView1.SortOrder.ToString() == "Ascending") // Check if sorting is Ascending
        { 
           dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name],ListSortDirection.Descending); 
          }
       else
         {
           dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name],ListSortDirection.Ascending); 
         }
    }
       
