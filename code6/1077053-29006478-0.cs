        public bool Open()
        {
            bool result = false;
            try
            {
                this.serialPort.Open();
                result = true;
                startReading = StartAsyncSerialReading;
                startReading();
            }
            catch (Exception)
            {
                this.Close();
                result = false;
            }
            return result;
        }
        private void StartAsyncSerialReading()
        {
            byte[] buffer = new byte[bufferLength];
            serialPort.BaseStream.BeginRead(buffer, 0, bufferLength, delegate(IAsyncResult ar)
            {
                try
                {
                    if (serialPort.IsOpen)
                    {
                        actualReadLength = serialPort.BaseStream.EndRead(ar);                        
                        received = new byte[actualReadLength];
                        DoYourStuffWithDataBuffer();
                    }
                }
                catch (IOException exc)
                {
                    //handleAppSerialError(exc);
                }
                if (serialPort.IsOpen)
                    startReading();
            }, null);
        }
           
        protected Stream GetStream()
        {
            return this.serialPort.BaseStream;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)                
                    this.serialPort.Dispose();
                
                this.disposed = true;
            }
        }
        public void Close()
        {
            this.serialPort.Close();
            this.Dispose();
        }
