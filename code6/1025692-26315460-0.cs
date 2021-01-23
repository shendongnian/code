    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    { 
        ...
        Console.WriteLine(sms.GetTimestamp());
        //Console.ReadKey();
        //Console.ReadKey();
    }
