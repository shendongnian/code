      public enum SerialSignal
      {
          SendSync = 0x33,
          ReceiveSync = 0x8A,
      }   
    private static SerialPort _arduinoSerialPort ;
    /// <summary>
    /// Polls all serial port and check for our device connected or not
    /// </summary>
    /// <returns>True: if our device is connected</returns>
    public static bool Initialize()
    {
        var serialPortNames = SerialPort.GetPortNames();
        foreach (var serialPortName in serialPortNames)
        {
            try
            {
                _arduinoSerialPort = new SerialPort(serialPortName) { BaudRate = 9600 };
                _arduinoSerialPort.Open();
                _arduinoSerialPort.DiscardInBuffer();
                _arduinoSerialPort.Write(new byte[] { (int)SerialSignal.SendSync }, 0, 1);
                var readBuffer = new byte[1];
                Thread.Sleep(500);
                _arduinoSerialPort.ReadTimeout = 5000;
                _arduinoSerialPort.WriteTimeout = 5000;
                _arduinoSerialPort.Read(readBuffer, 0, 1);
                // Check if it is our device or Not;
                if (readBuffer[0] == (byte)SerialSignal.ReceiveSync){
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception at Serial Port:" + serialPortName + Environment.NewLine +
                                "Additional Message: " + ex.Message);
            }
            // if the send Sync repply not received just release resourceses
            if (_arduinoSerialPort != null) _arduinoSerialPort.Dispose(); 
        }
        return false;
    }
