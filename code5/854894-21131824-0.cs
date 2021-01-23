    GridViewRow gvRow = (GridViewRow)((Button)sender).Parent.Parent;
    int ID = Convert.ToInt32(grdView.DataKeys[gvRow.RowIndex]["ID"]);
    
    DataTable grdContent = (DataTable)ViewState["grdContent"];
    
    foreach (DataRow dr in grdContent.Rows)
    {
        if (dr["ID"].ToString() == ID.ToString())
        {
            grdContent.Rows.Remove(dr);
            grdContent.AcceptChanges();
            break;
        }
    }
    
    grdView.DataSource = grdContent;
    grdView.DataBind();
