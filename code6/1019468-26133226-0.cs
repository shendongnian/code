    // Update Relay
	serialPort2.Close();
	serialPort2.PortName="COM3";
	serialPort2.Encoding = System.Text.Encoding.GetEncoding("Windows-1252");
	serialPort2.BaudRate=9600;
	serialPort2.DataBits=8;
	serialPort2.Parity=Parity.None;
	serialPort2.StopBits= StopBits.One; 
	try {serialPort2.Open();
	    serialPort2.Write("\u00a0\u0001\u0001\u00a2");
	} catch {
		// Open Serial Port Failed
		label1.Text=label1.Text+ " Fail";
	}
