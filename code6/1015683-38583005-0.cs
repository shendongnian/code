        System.Web.UI.WebControls.TextBox tbFilterArticle;
        protected void GridView_Imported_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridView_Imported.HeaderRow != null)
            {
                tbFilterArticle = (System.Web.UI.WebControls.TextBox)GridView_Imported.HeaderRow.FindControl("tbSearchUser");
            }
        }
