    <DataGrid ... PreviewMouseLeftButtonDown="Previe_Mouse_LBtnDown" >
        ...
    </DataGrid>
    private void Previe_Mouse_LBtnDown(object sender, MouseButtonEventArgs e)
    {
    	DataGridRow dgr = null;
    	var visParent = VisualTreeHelper.GetParent(e.OriginalSource as FrameworkElement);
    	while (dgr == null && visParent != null)
    	{
    		dgr = visParent as DataGridRow;
    		visParent = VisualTreeHelper.GetParent(visParent);
    	}
    	if (dgr == null) { return; }
    	var idx=dgr.GetIndex();
    }
