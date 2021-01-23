     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con1.Open();
    
            SqlCommand releaseTitlecmd = new SqlCommand("select Title from LWMDemo_ReleaseInfo order by ReleaseID", con1);
           SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Cmd;
            sda.Fill(ds);
            if(ds!=null && ds.table.count>0){
            if(ds.table[0]!=null && ds.table[0].rows.count>0){
                drpReleaseTitle.DataSource=ds.table[0].Title;  //Title Column
                 drpReleaseTitle.DataSourceID=ds.table[0].ID;  //ID Column
            }
        }
            con1.Close();
        }
    }
