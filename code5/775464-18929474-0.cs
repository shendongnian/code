    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cb = new CheckBox();
            if(e.Row.Cells["Column Name"].toString == true ){
                 cb.Checked = true; 
            }else{
                 cb.Checked = false;   
            }
            e.Row.Cells["Column Name"].Controls.Add(cb);
        }
    }
