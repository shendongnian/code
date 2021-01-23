    class SerialThing
    {
        public delegate void DataReceivedDelegate(string data);
        public event DataReceivedDelegate DataReceived;
        static SerialPort myDevice;
        public SerialThing()
        {
            myDevice = new SerialPort();
            myDevice.DataReceived += new SerialDataReceivedEventHandler(myDevice_DataReceived);
        }
        void myDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // ... grab the data and place into a string called "data" ...
            string data = "";
            // raise our custom event:
            if (DataReceived != null)
            {
                DataReceived(data);
            }
        }
    }
