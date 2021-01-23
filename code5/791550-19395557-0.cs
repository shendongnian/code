    //First you have to layout 2 DataGridViews at design time and set the Visible of the second 
    //DataGridView to false
    //Your dataGridView2 should also have 2 columns added at design time as shown
    //in your second picture.
    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e){
      //Suppose the column with header Total kaka has name TotalKaka
      if (dataGridView1.Columns[e.ColumnIndex].Name == "TotalKaka") {
          int i;
          if (int.TryParse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), out i))
          {
              dataGridView2.Rows.Clear();
              dataGridView2.Rows.Add(i);
              dataGridView2.Show();
              dataGridView2.Focus();
          }
      }
    }
    //you should have some Submit button to submit the values entered into the second
    //dataGridView, we should process something and surely hide the dataGridView2
    private void submit_Click(object sender, EventArgs e){
        dataGridView2.Hide();
        //other code to process your data
        //....
    }
