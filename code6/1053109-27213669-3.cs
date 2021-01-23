       protected void grdPostPageData_DataBound(object sender, EventArgs e)
        {
            
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 0; i < grdPostData.Columns.Count; i++)
            {
                TableHeaderCell cell = new TableHeaderCell();
                TextBox txtSearch = new TextBox();
                txtSearch.Attributes["placeholder"] = grdPostData.Columns[i].HeaderText;
                txtSearch.CssClass = "form-control HaydaBre";
                cell.Controls.Add(txtSearch);
                row.Controls.Add(cell);
            }
            if (grdPostData.Rows.Count > 0)
            {
                grdPostData.HeaderRow.Parent.Controls.AddAt(0, row);
            }
            else
            {
            }
        }
        
        protected void grdPostData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*
            if (e.Row.RowType == DataControlRowType.Header)
            {
                
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                for (int i = 0; i < grdPostData.Columns.Count; i++)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    TextBox txtSearch = new TextBox();
                    txtSearch.Attributes["placeholder"] = grdPostData.Columns[i].HeaderText;
                    txtSearch.CssClass = "form-control HaydaBre";
                    cell.Controls.Add(txtSearch);
                    row.Controls.Add(cell);
                }
                 grdPostData.HeaderRow.Parent.Controls.AddAt(-1, row);
               // e.Row.Parent.Controls.AddAt(1, row);
            }
            */
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from tbl_PostCategory ", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDownList DropDownList1 =
                    (DropDownList)e.Row.FindControl("ddlPostCategory");
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "cat_title";
                    DropDownList1.DataValueField = "cat_title";
                    DropDownList1.DataBind();
                }
            }
        }
