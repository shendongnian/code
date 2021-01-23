     protected void AmountDisplayed_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlPageSize = sender as DropDownList;
            if (ddlPageSize != null)
                this.gvCodes.PageSize = int.Parse(ddlPageSize.SelectedValue);
             if (ddlCodes.SelectedValue != "All" | ddlRegistered.SelectedValue != "All")
            {
                btnCodeSearch_Clicked(null, EventArgs.Empty);
            }
            else
            {
                BindCodes();
            }
            ddlPageSize.SelectedValue = this.gvCodes.PageSize.ToString();
        }
 
        protected void gvCodes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                DropDownList ddlPageSize = new DropDownList();
                ddlPageSize.AutoPostBack = true;
                ddlPageSize.SelectedIndexChanged += new EventHandler(AmountDisplayed_SelectedIndexChanged);
                ddlPageSize.Items.Clear();
                int[] pageSizeOptions = new int[] { 25, 50, 75, 100 };
                for (int i = 0; i < pageSizeOptions.Length; i++)
                {
                    ddlPageSize.Items.Add(pageSizeOptions[i].ToString());
                }
                Table pagerTable = e.Row.Cells[0].Controls[0] as Table;
                TableCell cell = new TableCell();
                cell.Controls.Add(new System.Web.UI.LiteralControl("Records per page:"));
                cell.Controls.Add(ddlPageSize);
                pagerTable.Rows[0].Cells.Add(cell);
                ddlPageSize.SelectedValue = this.gvCodes.PageSize.ToString();
            }
        }
