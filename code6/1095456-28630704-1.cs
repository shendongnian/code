    byte[] buffer = new byte[MAX_BUFFER];
    private volatile bool _ready = false;
    private Object _lock = new Object();
    
    public void serialPort1_DataRecived  (object sender, SerialDataReceivedEventArgs e)
    {
        DateTime time = DateTime.Now;
        // Either read as bytes or convert string to bytes, add to your buffer
        // string Rdata = serialPort1.ReadLine();
                
        lock(_lock )
        {
            if(_ready)
            {
                _ready = false;
                var myData = your buffer as string
                // clear buffer
                LogFile(myData, (int)numericSetpoint.Value);
                drawSetpoint(time,numericSetpoint.Value.ToString());
            }
        }
    }
    
    ...
    public void numericSetpoint_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13) 
        {
            if (serialPort1.IsOpen) 
            {
                int setpoint = (int)numericSetpoint.Value;
                //send to serial port .....     
                lock(_lock ) { _ready = true; }               
            }
        }
    }
    
