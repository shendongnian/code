    protected void GVAuthor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               var authorId = e.Row.DataItem("au_id");
               var ods = e.Row.FindControl("ObjectDataSource2") as ObjectDataSource;
               ods.InputParamenters["author_ID"] = authorId; 
            }
        }
