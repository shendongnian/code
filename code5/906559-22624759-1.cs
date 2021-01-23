    protected void Grd_View_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
            {
                int index = Grd_View.SelectedIndex;
                if (e.CommandName == "Edit")
                {
                   //...
                   loadgridview();
                }
                if (e.CommandName == "Delete")
                {
                   //...
                   loadgridview();
                }
              }
