    public void OpenArduinoConnection()
     {
         if(!arduinoBoard.IsOpen)
         {
             arduinoBoard.DataReceived += arduinoBoard_DataReceived;
             arduinoBoard.PortName = "yourportname";
             arduinoBoard.Open();
          }
          else
          {
             throw new InvalidOperationException("The Serial Port is already open!");
          }
     } 
    
    void arduinoBoard_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
       // your code here
    }
