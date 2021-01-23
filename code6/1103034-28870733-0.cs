        void Button1_Click(Object sender,  EventArgs e){
       
     //To append a row :
        
            TableRow addedRow = new TableRow();
            tb.Rows.Add(addedRow);
        
     //To add one or more cells to the row:
        
            TableCell addedCell = new TableCell();
            addedRow .Cells.Add(addedCell);
        }
