    public void BindGrid()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand("Select Id,cat_id, title, description, active from tbl_post Order by Id desc");
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        grdPostData.DataSource = dt;
                        grdPostData.DataBind();
                        DisablePageDirections();
                        grdPostData.BottomPagerRow.Visible = true;    //This will set the pagerTemplate visible even if you set the maximum value from the dropdownlist.
                    }
                }
            }
        }
