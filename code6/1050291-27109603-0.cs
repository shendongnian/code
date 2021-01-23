    protected void grdCSRPageData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer).RowIndex;
                grdCSRPageData.Rows.RemoveAt(rowIndex);
            }
        }
