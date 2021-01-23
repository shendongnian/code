    static void OpenConnections(CData deviceData) {
    
       CDevice deviceInstance = new CDevice((EDeviceType)Enum.Parse(typeof(EDeviceType), deviceData.Type));
       lock (m_sync) {
          m_deviceManager.AddDevice(deviceInstance);
       }
    
       // More stuff...
    }
