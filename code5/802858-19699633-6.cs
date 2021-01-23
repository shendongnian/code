      private void button1_Click(object sender, EventArgs e)
      {
        String sortedValue = dataGridView1.SortedColumn.Name == "Name" : table.Rows[0][0].ToString() ? table.Rows[0][1].ToString();
         MessageBox.Show(sortedValue);
      }
 
