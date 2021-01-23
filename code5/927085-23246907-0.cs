    public void AddButton()
        {
    
              // Create new row and add it to the table.
              TableRow tRow = new TableRow();
              Table1.Rows.Add(tRow);
              for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++) {
                 // Create a new cell and add it to the row.
                 TableCell tCell = new TableCell();
                 tCell.Text = "Row " + rowCtr + ", Cell " + cellCtr;
                 tRow.Cells.Add(tCell);
               Button bt = new Button();
               bt.text = "Click Me";
               bt.OnClick += OnClick;
               tRow.controls.add(bt);
    
        void GreetingBtn_Click(Object sender,  EventArgs e)
        {
          // do whatever you want to do 
        }
