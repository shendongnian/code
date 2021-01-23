    protected void Page_Load(object sender, EventArgs e)
    {
    
    if(!Page.IsPostBack)
    {
        Label1_pl.Text = Session["UserID"].ToString();
        string sqlstr = "select zzfname from sap_empmst where pernr = '" +  
        Label1_pl.Text + "'";
        DataSet ds = new DataSet();
        OracleDataAdapter adp = new OracleDataAdapter(sqlstr, con1);
        adp.Fill(ds);
        
        if(ds!=null)
        if(ds.Tables[0].Rows.Count>0)
    {
        string zzfname = ds.Tables[0].Rows[0]["zzfname"].ToString();
        Label2_name.Text = zzfname;
    }
    
    
    }
    
    }
