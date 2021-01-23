    string cString;
    SqlConnection Conn;
    string sqlCode = "";
    string strGender = "";
    int rowCount = 0;
    string strProv, strSpec, strLoca, strGend, strInsu, strLang;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        cString = ""; //my connection string
        if (!Page.IsPostBack)
        {
            PopulatePhysician();
            PopulateLocation();
            PopulateSpecialty();
            PopulateInsurance();
            PopulateLanguage();
    		
    		Search();
        }
    }
    
    public void lbSearch_Click(object sender, EventArgs e)
    {
    	Response.Redirect(String.Format("~/search.aspx?name={0}&specialty={1}&location={2}", ddlProvider.SelectedItem.Text, ddlSpecialty.SelectedItem.Text, ddlLocation.SelectedItem.Text));
    }
    
    public void Search()
    {
        Conn = new SqlConnection(cString);
        Conn.Open();
    
        strGender = Request.QueryString["Gender"];
    
        if (Request.QueryString["Provider"] == "Any Provider")
        {
            strProv = "%";
        }
        else
        {
            strProv = Request.QueryString["Provider"];
        }
        if (Request.QueryString["Specialty"] == "Any Specialty")
        {
            strSpec = "%";
        }
        else
        {
            strSpec = Request.QueryString["Specialty"];
        }
        if (Request.QueryString["Location"] == "Any Location")
        {
            strLoca = "%";
        }
        else
        {
            strLoca = Request.QueryString["Location"];
        }
        if (Request.QueryString["Gender"] == "Any Gender")
        {
            strGend = "%";
        }
        else
        {
            strGend = Request.QueryString["Gender"];
        }
        if (Request.QueryString["Insurance"] == "Any Insurance")
        {
            strInsu = "%";
        }
        else
        {
            strInsu = Request.QueryString["Insurance"];
        }
        if (Request.QueryString["Language"] == "Any Language")
        {
            strLang = "%";
        }
        else
        {
            strLang = Request.QueryString["Language"];
        }
    
        using (SqlConnection scCon = new SqlConnection(cString))
        {
            using (SqlCommand scCmd = new SqlCommand("searchPhysician", scCon))
            {
                scCmd.CommandType = CommandType.StoredProcedure;
    
                scCmd.Parameters.Add("@strProvider", SqlDbType.VarChar).Value = strProv;
                scCmd.Parameters.Add("@strSpecialty", SqlDbType.VarChar).Value = strSpec;
                scCmd.Parameters.Add("@strLocation", SqlDbType.VarChar).Value = strLoca;
                scCmd.Parameters.Add("@strGender", SqlDbType.VarChar).Value = strGend;
                scCmd.Parameters.Add("@strInsurance", SqlDbType.VarChar).Value = strInsu;
                scCmd.Parameters.Add("@strLanguage", SqlDbType.VarChar).Value = strLang;
    
                scCon.Open();
                scCmd.ExecuteNonQuery();
    
                //rptSearchResult datasource = result from the above store procedure query
                //lblCount.Text = rptSearchResult.Items.Count
            }
        }
    }
