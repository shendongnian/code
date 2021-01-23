	var document = new FlowDocument();
	document.PagePadding = new Thickness(20, 60, 20, 20);
	document.ColumnGap = 0;
	var table = new Table();
	table.CellSpacing = 0;
	var quantityColumn = new TableColumn();
	quantityColumn.Width = new GridLength(80);
	var priceColumn = new TableColumn();
	priceColumn .Width = new GridLength(80);
	var textColumn = new TableColumn();
	textColumn.Width = new GridLength(500);
	
	table.Columns.Add(quantityColumn);
	table.Columns.Add(priceColumn);
	table.Columns.Add(textColumn);
	var rowGroup = new TableRowGroup();
	table.RowGroups.Add(rowGroup);
	foreach (var item in yourData)
	{
		//Add your data
		var itemRow = new TableRow();
                
        //Assuming your data item has Quantity, Price and Text
		itemRow.Cells.Add(new TableCell(new Paragraph(new Run(item.Quantity.ToString()))));
		itemRow.Cells.Add(new TableCell(new Paragraph(new Run(item.Price.ToString()))));
		itemRow.Cells.Add(new TableCell(new Paragraph(new Run(item.Text))));
		//Etc.
	}
	document.Blocks.Add(table);
