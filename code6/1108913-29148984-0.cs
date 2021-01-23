           protected void Page_Init(object source, System.EventArgs e)
           {
                 RadGrid adminGrid = new RadGrid();
                 adminGrid.NeedDataSource += new GridNeedDataSourceEventHandler(AdminGrid_NeedDataSource);
                 adminGrid.ID = "AdminGrid";
                 // lots of code building adminGrid 
                 this.GridPlaceHolder.Controls.Add(adminGrid);
           }
            protected void AdminGrid_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
            {
               // AdminGrid would be the variable name if the control was
               // in the page with a runat instead of added programmatically
               // with an id of AdminGrid
               RadGrid grid = this.GridPlaceHolder.FindControl("AdminGrid") as RadGrid;
               grid.DataSource = DataSource;
            }
