        void portTimer_Tick(object sender, EventArgs e)
        {
            if (receievedData.Length > 0)
            {
                lock (receivedDataLock)
                {
                    String data = receievedData.ToString();
                    // Do something with your string, then empty the StringBuilder
                    receievedData = new StringBuilder();
                }
            }
        }
