    HtmlTableRow row;
    HtmlTableCell cell;
    HtmlTable tableContent = new HtmlTable();
    
    tableContent.Border = 2;
    foreach (DataRow dataRow in tab.Rows)
    {
        var row1 = new HtmlTableRow();
        var row2 = new HtmlTableRow();
        cell = new HtmlTableCell();
        cell.InnerHtml = "cell1";
        cell.RowSpan = 2;
        row1.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerHtml = "cell2";
        row1.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerHtml = "cell3";
        row2.Cells.Add(cell);
    
        cell = new HtmlTableCell();
        cell.InnerHtml = "cell4";
        cell.RowSpan = 2;
        row1.Cells.Add(cell);
    
    
        tableContent.Rows.Add(row1);
        tableContent.Rows.Add(row2);
    }
    
    this.Controls.Add(tableContent);
    }
