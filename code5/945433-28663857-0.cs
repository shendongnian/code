    var printerStatusCommand = Encoding.GetEncoding(850).GetBytes(@"~HQES");
    try
    {
        var zebraConnection = new ZebraUsbStream();
    
        zebraConnection.Write(printerStatusCommand, 0, printerStatusCommand.Length);
    
        var statusReturn = new byte[800];
        var bytesRead = zebraConnection.Read(statusReturn, 0, 800);
    
        if (bytesRead >= 132)
        {
            var stringResult = Encoding.Default.GetString(statusReturn.ToArray());
            Console.WriteLine(stringResult);
        }
    }
    catch
    {
        Console.WriteLine("Error");
    }
