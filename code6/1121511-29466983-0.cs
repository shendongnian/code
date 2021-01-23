    private void CreateTable(short noOfRows)
    {
        PlaceHolder p1 = new PlaceHolder();
        Table table1 = new Table();
        table1.BorderWidth = 1;
        table1.BorderStyle = BorderStyle.Solid;
        TableRow[] rows = new TableRow[noOfRows];
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new TableRow();
        }
        table1.Rows.AddRange(rows);
        TextBox t1 = new TextBox();
        t1.Text = "Hello";
        t1.EnableViewState = true;
        TextBox t2 = new TextBox();
        t2.Text = "World";
        t2.EnableViewState = true;
        Button btnOk = new Button();
        btnOk.EnableViewState = true;
        btnOk.Text = "OK";
        Button btnCancel = new Button();
        btnCancel.EnableViewState = true;
        btnCancel.Text = "Cancel";
        TableCell cell1=new TableCell();
        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        cell1.Controls.Add(t1);
        cell2.Controls.Add(t2);
        cell3.Controls.Add(btnOk);
        cell4.Controls.Add(btnCancel);
        table1.Rows[0].Cells.AddAt(0, cell1);
        table1.Rows[0].Cells.AddAt(1, cell2);
        table1.Rows[1].Cells.AddAt(0, cell3);
        table1.Rows[1].Cells.AddAt(1, cell4);
        p1.Controls.Add(table1); 
        form1.Controls.Add(p1);        
        
    }
