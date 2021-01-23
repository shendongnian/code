    ColumnHeader headerFirst;
    ColumnHeader headerSecond;
    headerFirst = new ColumnHeader();
    headerSecond = new ColumnHeader();
    
    // Set the text, alignment and width for each column header.
    headerFirst.Text = "Recipient";
    headerFirst.TextAlign = HorizontalAlignment.Left;
    headerFirst.Width = 188;
    
    headerSecond.TextAlign = HorizontalAlignment.Left;
    headerSecond.Text = "Number of Reports";
    headerSecond.Width = 188;
    
    // Add the headers to the ListView control.
    ListView1.Columns.Add(headerFirst);
    ListView1.Columns.Add(headerSecond);
