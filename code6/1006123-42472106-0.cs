    private void yourDataGrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
    {
     var dataGridClipboardCellContent = new List<DataGridClipboardCellContent>(); 
     
     string prevCell = "";
     string curCell = ""; 
     
     foreach (DataGridClipboardCellContent cell in e.ClipboardRowContent)
     {
      //Gives you access item.Item or item.Content here
      //if you are using your struct (data type) you can recast it here curItem = (yourdatatype)item.Item;  
      curItem = cell.Item.ToString(); 
      
      if (curCell != prevCell)
       dataGridClipboardCellContent.Add(new DataGridClipboardCellContent(item, item.Column, curCell)); 
    
      prevCell = curCell;  
    
     }
     e.ClipboardRowContent.Clear();
     
     //Re-paste back into e.ClipboardRowContent, additionally if you have modified/formatted rows to your liking
     e.ClipboardRowContent.AddRange(dataGridClipboardCellContent);
    
    }
