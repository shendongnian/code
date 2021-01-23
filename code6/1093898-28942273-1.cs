    string printerIP = "10.200.49.230";
    string portName = "IP_"+printerIP;
    string serverName "printServer01";
    PrintServer ps = new PrintServer(@"\\" + serverName);
    
    ManagementClass printerPortClass = new ManagementClass("\\\\" + serverName + "\\root\\cimv2", "Win32_TCPIPPrinterPort", new ObjectGetOptions());
    printerPortClass.Get();
    var newPrinterPort = printerPortClass.CreateInstance();
    newPrinterPort.SetPropertyValue("Name", portName);
    newPrinterPort.SetPropertyValue("Protocol", 1);
    newPrinterPort.SetPropertyValue("HostAddress", PrinterIP);
    newPrinterPort.SetPropertyValue("PortNumber", 9100);
    newPrinterPort.SetPropertyValue("SNMPEnabled", false);
    newPrinterPort.Put();
    //install printer
    try
    {
        ps.InstallPrintQueue(
            "PrinterName",
            "DriverName",
            new String[] { portName },    //port_name
            "WinPrint",
            PrintQueueAttributes.Shared,//set it to shared
            "Sharename",
            "This is a comment for the printer",
            "This is the printers location",
            "", 1, 1        //priorities
            );
    }
    catch (Exception printerException)
    {
        //couldn't install printer
    }
