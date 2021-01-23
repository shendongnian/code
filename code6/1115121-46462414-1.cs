    // First, we create the table, its properties and we append it.
    Table table = new Table();
    TableProperties props = new TableProperties();
    table.AppendChild<TableProperties>(props);
    // Now we create a new layout and make it "fixed".
    TableLayout tl = new TableLayout(){ Type = TableLayoutValues.Fixed };
    props.TableLayout = tl;
    // Then we just create a new row and a few cells and we give them a width
    var tr = new TableRow();
    var tc1 = new TableCell();
    var tc2 = new TableCell();
    tc1.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2000" }));
    tc2.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2000" }));
    table.Append(tr);
