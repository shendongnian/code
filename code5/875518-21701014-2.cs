    var tables = new List<Table>();
    foreach(var table in document_div.Cq().Find("TABLE"))
    {
        var t = new Table();
        foreach(var tr in table.Cq().Find("TR"))
        {
            var r = new Row();
            foreach(var td in tr.Cq().Find("td"))
            {
                var c = new Cell();
                c.Contents = td.InnerHTML;
                r.Cells.Add(c);
            }
            t.Rows.Add(r);
        }
        tables.Add(t);
    }
    // Assuming the HTML was correct, now you have a cleanly organized 
    // class structure representing the tables!
    
    var aTable = tables.First();
    var firstRow = aTable.Rows.First();
    var firstCell = firstRow.Cells.First();
    var firstCellContents = firstCell.Contents;
    ...
