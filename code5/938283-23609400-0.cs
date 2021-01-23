    protected void Page_Load(object sender, EventArgs e)
            {
              DBConnect db = new DBConnect();
                SqlDataAdapter da = new SqlDataAdapter("SELECT USER_CODE,USER_FULL_NAME,USER_DEPT_NAME FROM USER_MASTER",db.connect());
        
                DataSet ds = new DataSet();
        
                da.Fill(ds);
                   if(!isPostBack)
                  {
    
                grd.DataSource = ds;
                grd.DataBind();
    
                 }
            }
