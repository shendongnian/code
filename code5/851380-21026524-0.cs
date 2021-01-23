    class Device
    {
      // device properties here
      int deviceState;
    }
    
    class Line
    {
      // line properties here
      int lineState;
      // devices associated with this line
      Device[] devices;
      // constructor
      Line()
      {
        devices = new Device[60];
      }
    }
    
    class Main
    {
      List[] lines;
      Main()
      {
        lines = new Lines[10];
        for(int i = 0; i < 10; ++i)
          HandleLine(i, line[i]);
      }
      void HandleLine(int lineNumber, Line line)
      {
        // get line status
        line.status = getLineStatus(lineNumber);
        // handle devices on this line
        for(int i = 0; i < 60; ++i)
          HandleDevice(lineNumber, i, line.devices[i]);
      }
      void HandleDevice(int lineNumber, int deviceNumber, Device device)
      {
        // get device status
        device.status = getDeviceStatus(lineNumber, deviceNumber);
      }
    }
