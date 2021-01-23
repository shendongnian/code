    private void ColorRows()
       {
         foreach (DataGridViewRow row in dataGridViewTest.Rows)
         {
           int value = Convert.ToInt32(row.Cells[0].Value);
           row.DefaultCellStyle.BackColor = GetColor(value);
         }
       }
     
       private Color GetColor(int value)
       {
         Color c = new Color();
         if (value == 0)
           c = Color.Red;
         return c;
       }
     
       private void dataGridViewTest_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
       {
         ColorRows();
       }
