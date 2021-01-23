        void ReceiveText(IAsyncResult res)
        {
            try
            {
                byte[] received = illReceive.EndReceive(res, ref RemoteIpEndPoint);
                returnData = Encoding.UTF8.GetString(received);
                InformUser(returnData);
                illReceive.BeginReceive(new AsyncCallback(RecieveText), null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
