    private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
    {
    	var user = gridView1.GetRow(e.RowHandle) as User;
    	if (user == null)
    		return;
    
    	WriteUsersInformation(user);
    }
