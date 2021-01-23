    CallStatusAvailability.ServiceReference1.StatusAvailabilityRoomsClient client = null;
    try
    {
       
       if (System.Configuration.ConfigurationManager.AppSettings["runMode"] == "live")
       {
           client = new CallStatusAvailability.ServiceReference1.StatusAvailabilityRoomsClient();
       }
       else
       {
           client = new CallStatusAvailability.StatusAvailabilityRooms.StatusAvailabilityRoomsClient();
       }
    }
    catch(..){}
    finally 
    { 
        client.Dispose();
    }
