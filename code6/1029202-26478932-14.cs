    SqlConnection conn = new SqlConnection("Your Connection String");
    SqlCommand comm = new SqlCommand("Your Store procedure name", conn); //you can use string query 
    comm.CommandType = CommandType.StoredProcedure; //Or Text when you use sql like when u use ttx b4.
    
    SqlDataAdapter da = new SqlDataAdapter(comm);
    
    da.SelectCommand.CommandTimeout =0;
    DataSet ds = new DataSet("Your dataset name");
    da.Fill(ds);
    
    if(ds.Tables[0].Rows.Count > 0)
    {
       ReportDocument doc = new ReportDocument(); //Your report Doc instance
       doc.Load("Report FIle path");
    
       //Below is important . Here you overwrite the datasource
       doc.Database.Tables[0].SetDataSource(ds.Tables[0]); //Set your report datasource,
       report.SetParameterValue(0, Loc); //Set your parameters; //You can manually add the parameters in   your report.
    
       crViewer.ReportSource = doc; //Set your Report Viewer source .  And you are good to go. 
    
    }
