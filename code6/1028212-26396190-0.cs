    public void BindModels(int manufacturer)
    {
        int numberOfModels;
        string strConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ToString();
        SqlConnection conn = new SqlConnection(strConnectionString);  // Connect to Carsales database
        conn.Open();                                   // Select all models for a particular make
        string com = "SELECT ModelID, ModelName From VehiclesModels Where ManufacturerID = " + manufacturer + "  ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, conn); // Convert the database string to an sqldata adapter
        DataTable dt = new DataTable();            // Create a data table for binding
        numberOfModels = adpt.Fill(dt);// Determine number of models for this manufacturer before binding
                                           // Fill the data table with the open Sql connection
        drpModel.DataSource = dt;          // dropdownlist data source is newly created table
        drpModel.DataTextField = "ModelName"; // relate database fields to dropdownlist fields
        drpModel.DataValueField = "ModelID";  // Model ID goes in the value field
        drpModel.DataBind();                  // Data bind to the dropdown list in the front end
        switch (numberOfModels)
        {
            case 0: hdnModelID.Value = "-1";   // If no models exist for this manufacturer, Indicate this via hdnModelID value
                    txtMessage.Text = "No models exist for this manufacturer"; // Give user a message.
                    break;
            case 1 : BindGrid4BodyDetails(Convert.ToInt32(drpModel.SelectedValue)); // If only one model (Special case)
                                             // Bind the grid for body details for this model
                     hdnModelID.Value = drpModel.SelectedValue;  // Indicate the only possible selection as the current ModelId value
                     break;
            default : break;
        }
        conn.Close();                   // Close the connection to the carsales database
    }
