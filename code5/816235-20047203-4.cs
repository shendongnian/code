    private void grdviewAllocations_CustomUnboundColumnData(System.Object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
    	try {
    		if (e.Column.Name == MyColumn.Name && e.RowHandle >= 0) {
    			e.Value = ((MyObject)e.Row).EmplPoco.Name;
    		}
    	} catch (Exception ex) {
    		//Handle exception here
    	}
    }
