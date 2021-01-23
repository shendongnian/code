     for (int rowctr = 0; rowctr < sqlcolumn.Length; rowctr++)
        {
            TableRow myrow = new TableRow();
            mytable.Rows.Add(myrow);
    
    
           // for (int cellctr = 0; cellctr < 1; cellctr++)
            //{
    		DropDownList drd = new DropDownList();
               foreach (String colname in sqlcolumn)
              {
                 drd.Items.Add(colname);
              }
    
                TableCell mycell = new TableCell();
                mycell.Controls.Add(drd);
                myrow.Cells.Add(mycell);
            //}
           mytable.Rows.Add(myrow);
         }
