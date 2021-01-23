            if(!serialPort1.IsOpen)
            {
                serialPort1.PortName = "COM3";
                try
                {
                    serialPort1.Open();
                }
                catch
                {
                    // Add exception handling here
                }
            }
