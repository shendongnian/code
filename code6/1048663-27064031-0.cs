    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        StringBuilder b = new StringBuilder();
        while(!IsValidBarcode(b.ToString())) 
        {
            b.Append(sp.ReadExisting());
        }
        Console.WriteLine("Data Received:");
        Console.WriteLine(b.ToString());
    }
    private static Boolean IsValidBarcode(String s)
    {
        if (String.IsNullOrEmpty(s)) return false;
        // (1) Query a database for expected barcodes ...
        // (2) Check s for Start-Stop-Characters ...
        // (3) Query the device for completed barcode ...
        throw new NotImplementedException();
    }
