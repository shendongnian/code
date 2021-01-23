    private void grdview_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
    	try {
    		if (e.Column.Name == MyColumn.Name && e.RowHandle >= 0) {
    			e.DisplayText = ((EmplPoco)e.Value).Name;
    		}
    	} catch (Exception ex) {
    		//Handle exception here
    	}
    }
