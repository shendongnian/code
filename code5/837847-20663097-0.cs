    protected void GridView1_RowDataBound(Object sender, System.Web.UI.WebControls.GridViewRowEventArgs e){
        if(e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit){
            TextBox txt = e.Row.FindControl('lblTab1');
            if(txt != null){
                DataRowView drv = e.Row.DataItem;
                txt.Text = drv('Name');
            }
        }
    }
