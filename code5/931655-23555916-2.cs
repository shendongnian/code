    static void ue_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
	{
		var ue = e.OriginalSource as FrameworkElement;
		DataGrid dg = FindVisualParent<DataGrid>(ue) as DataGrid;
		DataGridCell cell = FindVisualParent<DataGridCell>(ue);
	   
		if (e.Key == Key.Enter)
		{
			//e.Handled = true;
			if (dg != null)
			{
				dg.CommitEdit();
			}
			
			if (cell != null)
			{
				cell.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
			else
			{
				ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
			
			if (dg != null)
			{
				dg.BeginEdit();
			}
		}
	}
