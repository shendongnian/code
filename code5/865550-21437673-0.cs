    private void BindMedicalDropdowns()
    		{
    
    			string constr = ConfigurationManager.ConnectionStrings["sacpConnectionString"].ToString(); // connection string
    			SqlConnection con = new SqlConnection(constr);
    			con.Open();
    
    			//SqlCommand com = new SqlCommand("select * from MEDICALCENTRE", con); // table name 
    			SqlCommand com = new SqlCommand("select mcCentre from MEDICALCENTRE", con); // table name 
    			SqlDataAdapter da = new SqlDataAdapter(com);
    			DataSet ds = new DataSet();
    			da.Fill(ds);  // fill dataset
    			//ddlMedicalCentre.DataTextField = ds.Tables[0].Columns["mcID"].ToString(); // text field name of table dispalyed in dropdown
    			//ddlMedicalCentre.DataValueField = ds.Tables[0].Columns["mcID"].ToString();             // to retrive specific  textfield name 
    			ddlMedicalCentre.DataTextField = ds.Tables[0].Columns["mcCentre"].ToString(); // text field name of table dispalyed in dropdown
    			ddlMedicalCentre.DataValueField = ds.Tables[0].Columns["mcCentre"].ToString();             // to retrive specific  textfield name 
    			ddlMedicalCentre.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
    			ddlMedicalCentre.DataBind();  //binding dropdownlist
    		}
