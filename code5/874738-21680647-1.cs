    private void Resize()
    {	
	myListView.Columns[0].Width = -2;            
	myListView.Columns[1].Width = -2;
	myListView.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.None); // This one
	myListView.Columns[2].Width += myListView.Width 
								   - myListView.Columns.Cast<ColumnHeader>().Sum(column => column.Width)
								   - (myListView.BorderStyle == BorderStyle.Fixed3D ? 4 : 2)
								   - SystemInformation.VerticalScrollBarWidth;
    }
