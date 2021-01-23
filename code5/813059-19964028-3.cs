    //for user removing rows
    dataGridView1.UserDeletingRow += (s, e) => {
      sum -= ((double?) e.Row.Cells["sumColumn"].Value).GetValueOrDefault();
      textBox9.Text = sum.ToString();
    };
    //for code removing rows, use some method to remove rows like this:
    public void RemoveRows(DataGridView grid, int startIndex, int count){
      for(int i = startIndex; i <= startIndex + count; i++){
         //update the sum first
         sum -= ((double?)grid.Rows[i].Cells["sumColumn"].Value).GetValueOrDefault();
         //then remove the row
         grid.Rows.RemoveAt(startIndex);
      }
      textBox9.Text = sum.ToString();
    }
