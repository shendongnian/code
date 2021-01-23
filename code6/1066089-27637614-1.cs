    Label lblDeviceInformation = (Label)GridView3.FindControl("DeviceInformation");
    int rowCount = GridView3.Rows.Count;
    if (rowCount == 0)
    {
    lblDeviceInformation .Visible= False;
    }
    else
    {
    lblDeviceInformation .Visible= True;
    }
    
  
  
