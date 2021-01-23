        private async void sendData(string dataToSend)
        {
            if (!connected)
            {
                StatusLabel.Text = "Status: Must be connected to send!";
                return;
            }
            try
            {
                byte[] data = GetBytes(dataToSend);
                IBuffer buffer = data.AsBuffer();
                StatusLabel.Text = "Status: Trying to send data ...";
                await clientSocket.OutputStream.WriteAsync(buffer);
                StatusLabel.Text = "Status: Data was sent" + Environment.NewLine;
            }
            catch (Exception exception)
            {
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                    throw;
                }
                StatusLabel.Text = "Status: Send data or receive failed with error: " + exception.Message;
                closing = true;
                clientSocket.Dispose();
                clientSocket = null;
                connected = false;
            }
            readData();
        }
        private async void readData()
        {
            StatusLabel.Text = "Trying to receive data ...";
            try
            {
                IBuffer buffer = new byte[1024].AsBuffer();
                await clientSocket.InputStream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.Partial);
                byte[] result = buffer.ToArray();
                StatusLabel.Text = GetString(result);
            }
            catch (Exception exception)
            {
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                    throw;
                }
                StatusLabel.Text = "Receive failed with error: " + exception.Message;
                closing = true;
                clientSocket.Dispose();
                clientSocket = null;
                connected = false;
            }
        }
