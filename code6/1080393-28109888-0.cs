    var readQueue = string.Empty;
    private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
    {
        readQueue += port.ReadExisting();
        while (readQueue.Substring(1).Contains(@"\"))
        {
            var slashPos = readQueue.IndexOf(@"\",1);
            var completeEntry = readQueue.Substring(0, slashPos);
            Console.WriteLine(completeEntry);
            readQueue = readQueue.Substring(slashPos);
        }
    }
