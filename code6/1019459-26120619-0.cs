    void TraverseRows(ColumnView view,bool selectRemove)
    {
        dtTemp = new Data.Medical.Follow.DSFollow.FollowRequestsDataTable();
        for (int i = 0; i < gridViewList.RowCount; i++)
        {
            DataRow row = gridViewList.GetDataRow(gridViewList.GetVisibleRowHandle(i));
            row["is_selected"] = selectRemove;
            dtTemp.AddFollowRequestsRow((DSFollow.FollowRequestsRow)row);
        }
    }
