    protected void Page_Load(object sender, EventArgs e)
            {
                ListView1.DataSource = this.GetData();
                ListView1.DataBind();
            }
    
            private DataSet GetData()
            {
                string conString = ConfigurationManager.ConnectionStrings["Connectionstr"].ConnectionString;
                string query = "SELECT * FROM Registration";
                SqlCommand cmd = new SqlCommand(query);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
