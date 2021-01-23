    Static String inDataA, inDataB;
    
    // Receive data on COM Port A
    private static void DataReceivedHandlerA(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        inDataA = sp.ReadExisting();
        Console.Write(inDataA);
    }
    
    // Receive data on COM Port B
    private static void DataReceivedHandlerB(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort spB = (SerialPort)sender;
        inDataB = spB.ReadExisting();
        Console.Write(inDataB);
    }
    
    
    //use those variables here as well in some other functions
