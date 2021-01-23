    protected void Page_Load(object sender, EventArgs e)
        {
          SqlConnection con;
          SqlDataAdapter da;
          DataSet ds;
          SqlCommand cmd;        
    
         con = new       
              SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
         con.Open();
    
         da = new SqlDataAdapter("select Id,Name,Dept,Image from tablename",con);
         ds = new DataSet();
         da.Fill(ds);
         gdImage.DataSource = ds;
         gdImage.DataBind();
        }
