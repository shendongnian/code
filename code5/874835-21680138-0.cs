        ArrayList myArrayList = new ArrayList();
        //Fill ArrayList values from the SQL Server
        myArrayList.Add("Hello");
        myArrayList.Add("World");
        Table table = new Table();
        foreach (var item in myArrayList)
        {
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            
            //Add Arraylist item into TableCell to display it
            tc.Text = item.ToString();
            tr.Cells.Add(tc);
            table.Rows.Add(tr);
           
        }
