    Object lockObject = new Object();
    private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        lock(lockObject)
        {
            try
            {
                data = serialPort.ReadLine();
            }
            catch(System.IO.IOException ex)
            {
                //since serial port reading threw an error so there is no value to be parsed hence exit the function.
                return;
            }
        }
        //if no error then parse the data received
    }
