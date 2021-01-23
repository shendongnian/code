    <asp:DropDownList ID="ddlFacilityType" runat="server" onselectedindexchanged="ddlFacilityType_SelectedIndexChanged" AutoPostBack="true">   
    protected void ddlFacilityType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    
                string constr = ConfigurationManager.ConnectionStrings["sacpConnectionString"].ToString(); // connection string
                SqlConnection con = new SqlConnection(constr);
                con.Open();
    
    
                SqlCommand com = new SqlCommand("select distinct FAC_CODE from FACILITIES where FAC_TYPE='"+ddlFacilityType.SelectedValue.ToString()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
    
                ddlFacility.DataTextField = ds.Tables[0].Columns["FAC_CODE"].ToString(); // text field name of table dispalyed in dropdown
                // to retrive specific  textfield name 
                ddlFacility.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                ddlFacility.DataBind();  //binding dropdownlist
    
    
    }
 
