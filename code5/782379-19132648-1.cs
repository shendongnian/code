    protected void Page_Load(object sender, EventArgs e)
    {        
        DataTable dt = getData();
        GridView1.DataSource = dt;
        GridView1.DataBind();
      }
    
    public  DataTable getData() 
    {
      SqlDataAdapter dap = new SqlDataAdapter("select characterID,blueBallImage,gameLevel from CorrespondingBall", cn);
      DataSet ds = new DataSet();
      dap.Fill(ds);
      return ds.Tables[0];
    }
