    private void appPivot_LoadedPivotItem(object sender, PivotItemEventArgs e)
    {
		if ( e.Item.Name.CompareTo( "pivot_item1" ) == 0 )
		{
			StackPanel sp1 = StackPanel1;
		}
		else
		{
			StackPanel sp2 = StackPanel2;
		}
    }
