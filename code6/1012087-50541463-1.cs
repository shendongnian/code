     private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
      
     {
          
     ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            
     {
                  
     try
         {
            string name = property.Value.ToString();//name of your device
            string deviceId = instance.GetPropertyValue("PNPDeviceID").ToString();
            if (name == "something")
                    {
                     ....your code.....
                    }
         }
     catch
         {
         }
     }
     }
