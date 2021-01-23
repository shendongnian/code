    private void gridViewData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
    {
        if (e.Clicks == 2)
        {
            DataEntry entry = gridViewData.GetRow(e.RowHandle) as DataEntry;
            if (entry != null)
            {
                Debug.Print(entry.Number);
            }
        }
    }
