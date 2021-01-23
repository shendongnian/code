    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
       if(dataGridView1[e.ColumnIndex, e.RowIndex] == null) return;
       // rest of code as in the upper one
    }
    
    private void dataGridView1_CellValidating(object sender, DataGridViewCellEventArgs e)
    {
       int col = e.ColumnIndex;
       int row = e.RowIndex;
       string data = e.FormattedValue.ToString();
       
       if(!checkData(data))
       {
         e.Cancel = false;
         return;
       }
    
       // for example I want to limit the quantities to be between [0, 100]
    
       if(col == 2)
       {
         int iData = Convert.ToInt32(data);
         if(iData < 0 || iDat > 100)
         {
           e.Cancel = true;
           return;
         }
       }
       
       
    }
    
       
    private bool chackData(string d)
    {
       if (d.Length <= 0 || d.Length >= 10) return false;
    
       foreach (char c in d)
       {
         if('0' >= c || c >= '9')
         {
            return false;
         }
       }
       return true;
    }
