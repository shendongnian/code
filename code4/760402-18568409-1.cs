     for (int rowctr = 0; rowctr < sqlcolumn.Length; rowctr++)
        {
            TableCell mycell = new TableCell();
            TableCell mycell1 = new TableCell();
            
            for (int cellctr = 0; cellctr < 1; cellctr++)
            {
                DropDownList drd = new DropDownList();
                foreach (String colname in sqlcolumn)
                {
                    drd.Items.Add(colname);
                    
                }
                DropDownList drd1 = new DropDownList();
                foreach (string colnames in excel)
                {
                    drd1.Items.Add(colnames);
                }
                
                TableRow myrow = new TableRow();
            
                
                mycell.Controls.Add(drd);
                mycell1.Controls.Add(drd1);            
                myrow.Cells.Add(mycell);
                myrow.Cells.Add(mycell1);
                mytable.Rows.Add(myrow);
    }
    Panel1.Controls.Add(mytable);
