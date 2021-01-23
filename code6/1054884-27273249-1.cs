    public class MyClass
    {
      HIDNewDeviceMonitor monitor;
      public MyClass()
      {
        monitor = new HIDNewDeviceMonitor();
        monitor.Inserted += DeviceInserted;
      } 
      
      private void DeviceInserted(string deviceName) 
      { 
       // Execute code here
      }
    }
