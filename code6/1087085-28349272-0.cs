        private void serialPortN_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte [] buffer = new byte[serialPortN.BytesToRead];
            int numRead = serialPortN.Read(buffer,0,buffer.Length);            
            // Ensure we arent trying to modify string builder from 2 different threads simultaneously
            lock(receivedDataLock){
                // Assuming the data is in ASCII text format if you are displaying to text box            
                receievedData.Append(System.Text.Encoding.ASCII.GetString(buffer));
            }
        }
