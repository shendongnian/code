     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    FillGridView();
                }
            }
            protected void FillGridView()
            {
                string query = "Select Column1, Registereddate from tablename";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gdviewevent.DataSource = dt;
                    gdviewevent.DataBind();
                    ViewState["dirState"] = dt;
                    ViewState["sortdr"] = "Asc";
                }
            }
    
            protected void gdviewevent_Sorting(object sender, GridViewSortEventArgs e)
            {
                DataTable dtrslt = (DataTable)ViewState["dirState"];
                if (dtrslt.Rows.Count > 0)
                {
                    if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                    {
                        dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                        ViewState["sortdr"] = "Desc";
                    }
                    else
                    {
                        dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                        ViewState["sortdr"] = "Asc";
                    }
                    gdviewevent.DataSource = dtrslt;
                    gdviewevent.DataBind();
                }
    
            }
