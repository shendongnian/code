    public string autotag="";
        protected void Page_Load(object sender, EventArgs e)
        {
            bind1();
        }
        public void bind1()
        {
    
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            con.Open();
            string query="select name from tbl_data_show";
            SqlCommand cmd=new SqlCommand(query,con);
            SqlDataReader dr=cmd.ExecuteReader();
            dr.Read();
            while(dr.Read())
            {
                if(string.IsNullOrEmpty(autotag))
                {
                    autotag+="\""+dr["name"].ToString()+"\"";
                }
                else
                {
                    autotag+=", \""+dr["name"].ToString()+"\"";
                }
            }
        }
