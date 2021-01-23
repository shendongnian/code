        public void Send(Bitmap bmp)
        {
            // prepare Bitmap
            BitmapTransmission bt = new BitmapTransmission(bmp);
            
            // try transmitting the object
            try
            {
                // lock to exclude other Threads of using the stream
                lock (m_objSendLock)
                {
                    bt.Send(m_stream);                    
                }
            } 
            catch (BitmapTransmissionException ex) 
            { // will catch any exception thrown in bt.Send(...)
                Debug.Print("BitmapHeaderException: " + ex.Message);
                ///BitmapTransmissionException provides a Property `CloseConnection`
                /// it will inform you whether the Exception is recoverable
            }
        }
