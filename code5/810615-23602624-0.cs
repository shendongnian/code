    try
		{
			ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSSerial_PortName");
			foreach (ManagementObject queryObj in searcher.Get())
			{
				serialPort = new SerialPort(queryObj["PortName"].ToString(), 115200, Parity.None, 8, StopBits.One);//change parameters
				//If the serial port's instance name contains USB
				//it must be a USB to serial device
				if (queryObj["InstanceName"].ToString().Contains("USB"))//if you have a VID or PID name then this should not be nessesery
				{
					//should get serial to usb adapters
					try
					{
						serialPort.Open();
						if (queryObj["InstanceName"].ToString().Contains(VID_or_PID))
						{
							//do sth
						}
						serialPort.Close();
					}
					catch (Exception ex)
					{
						//exception handling
					}
				}
				
			}
		}
		catch (ManagementException ex)
		{
			//write("Querying for WMI data. Exception raised(" + ex.Message + "): " + ex);
		}
