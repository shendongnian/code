    protected void gvDocsVerPrev_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Get data row view
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkbox= e.Row.FindControl("chkbox") as CheckBox ;
                if (chkbox.Selected)
                {
                    e.Row.CssClass = "blue";
                }
            }
        }
