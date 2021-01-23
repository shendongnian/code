    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        StringBuilder b = new StringBuilder();
        Thread.Sleep(1000);     // 1 second delay for testing purposes
        b.Append(sp.ReadExisting());
        Console.WriteLine("Data Received:");
        Console.WriteLine(b.ToString());
    }
