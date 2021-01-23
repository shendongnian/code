    // object to InContact Web Service reference
    var client = new icContactSR.inSideWS()
    {
    	inCredentialsValue = new icContactSR.inCredentials()
    	{
    		password = ******,
    		busNo = ******,
    		timeZoneName = "UTC"
    	}
    };
    
    DateTime startDate = new DateTime(2013, 12, 27, 8, 00, 00);
    DateTime endDate = new DateTime(2013, 12, 27, 9, 00, 00);
    
    DataSet dsCallDetails = client.DataDownloadReport_Run(report_number, startDate.ToUniversalTime(), endDate.ToUniversalTime());
    
    GridView1.DataSource = dsCallDetails.Tables[0];
    GridView1.DataBind();
