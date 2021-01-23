    public void ProcessRequest(HttpContext context)
    {
      //get the image from data base in here im using a web service
        System.Data.DataSet ds = new System.Data.DataSet();
        MMS_MasterWebService.MMS_MasterMaintenance obj = new MMS_MasterWebService.MMS_MasterMaintenance();
        obj.Url =  "http://192.168.48.10/SHOREVision_MMS_Service/MMS_MasterMaintenance.asmx";
        ds = obj.GetVehicleMasterByCode(para);
        context.Response.BinaryWrite((byte[])ds.Tables[0].Rows[0][21]);
    }
