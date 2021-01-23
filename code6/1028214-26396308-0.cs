    public void BindModels(int manufacturer)
    {
        int numberOfModels;
        string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ToString();
        SqlConnection conn = new SqlConnection(strConnectionString); 
        conn.Open();                            
        string com = "SELECT ModelID, ModelName From VehiclesModels Where ManufacturerID = " + manufacturer + "  ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
        DataTable dt = new DataTable();      
        numberOfModels = adpt.Fill(dt);      
    
        // set the DataTable as the DataSource, no items will be added to the DropDownList control if the DataTable has no records
	    drpModel.DataSource = dt;        		
	    drpModel.DataTextField = "ModelName"; 
	    drpModel.DataValueField = "ModelID";  
	    drpModel.DataBind();                  
           
	    if (numberOfModels == 1)              
     	{
	        BindGrid4BodyDetails(Convert.ToInt32(drpModel.SelectedValue)); 
	    }
	    hdnModelID.Value = drpModel.SelectedValue; 
        
        conn.Close();             
    }
