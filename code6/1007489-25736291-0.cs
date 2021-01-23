        string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["New"] != null)
            {
                Label_welcome.Text += Session["New"].ToString();
            }
            else
                Response.Redirect("MainPage.aspx");
            
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            string qry1 = "SELECT [USERNAME], [EMAIL], [PASSWORD], [STATE], [NAME], [CNAME], [ADDRESS], [TELEPHONE], [FAX], [TYPE], [AGENT] FROM [Registration] WHERE ([USERNAME] LIKE '%' + @USERNAME + '%')";
            SqlDataAdapter da = new SqlDataAdapter(qry1, conn);
            SqlCommand com = new SqlCommand(qry1, conn);
            da.SelectCommand.Parameters.AddWithValue("@USERNAME", TextBoxSearch.Text);
            da.Fill(dt);
            GridView1.DataSourceID = string.Empty;
            GridView1.DataSource = dt;
        
        }
        protected void GridView1_OnRowSelected(object sender, GridViewSelectEventArgs e)
        {
            var username = Convert.ToString(GridView1.DataKeys[e.NewSelectedIndex].Value);
            Response.Redirect("ViewUploads.aspx?USERNAME=" +username);
        
        }
