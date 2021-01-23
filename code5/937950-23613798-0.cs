    private void DoReceiveFrom(IAsyncResult iar)
    {
        try
        {
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
            int dataLen = 0;
            byte[] data = null;
            try
            {
                dataLen = this.serverSocket.EndReceiveFrom(iar, ref clientEP);
                data = new byte[dataLen];
                Array.Copy(this.byteData, data, dataLen);
            }
            catch(Exception e)
            {
            }
            finally
            {
                EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
                this.serverSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, newClientEP);
            }
            if (!this.clientList.Any(client => client.Equals(clientEP)))
                this.clientList.Add(clientEP);
            DataList.Add(Tuple.Create(clientEP, data));
        }
        catch (ObjectDisposedException)
        {
        }
    }
