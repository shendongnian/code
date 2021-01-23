    private void myDataGridView_CellEnter(object sender, DataGridViewCellCancelEventArgs e)
    {
    //get the column index of your columns 
    //Here you dont need to call grid name just e is enough 
    //Note you can try e.Name may be , but i didn't 
    if (e.ColumnIndex == colIndex1 || e.ColumnIndex == colIndex2)
        {
               myDropDownButton.Enabled = true;
         }
      else
         {
                myDropDownButton.Enabled = false;
           }
    }
