    class Transmitter
    {
        LibWrapper lib = new LibWrapper();
        private ManualResetEvent evt = new ManualResetEvent(false);
        byte[] data;
        public void OnDataSendingDone(UInt32 handle)
        {
            evt.Set();
        }
        public void TransmitData()
        {
            // here: sequential data transmission   
            foreach (byte b in data)
            {
                lib.SendByte(b);
                if (!evt.WaitOne(15000)) // or whatever timeout makes sense
                    throw new Exception("timed out");
            }
        }
    }
