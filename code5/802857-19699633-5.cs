      void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {            
          if (dataGridView1.SortOrder.ToString() == "Descending") // Check if sorting is Descending
          {
              table.DefaultView.Sort = dataGridView1.SortedColumn.Name + " DESC"; // Get Sorted Column name and sort it in Descending order
          }
          else
          {
            table.DefaultView.Sort = dataGridView1.SortedColumn.Name + " ASC";  // Otherwise sort it in Ascending order
          }
          table = table.DefaultView.ToTable(); // The Sorted View converted to DataTable and then assigned to table object.
      }
