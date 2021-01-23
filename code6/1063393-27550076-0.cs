	uint VisibleRows = 0;
	var TicketGrid = (DataGrid) MyWindow.FindName("TicketGrid");
	foreach(var Item in TicketGrid.Items) {
		var Row = (DataGridRow) TicketGrid.ItemContainerGenerator.ContainerFromItem(Item);
		if(Row != null) {
			/*
			   This is the magic line! We measure the Y position of the Row, relative to
			   the TicketGrid, adding the Row's height. If it exceeds the height of the
			   TicketGrid, it ain't visible!
			*/
			if(Row.TransformToVisual(TicketGrid).Transform(new Point(0, 0)).Y + Row.ActualHeight >= TicketGrid.ActualHeight) {
				break;
			}
			VisibleRows++;
		}
	}
