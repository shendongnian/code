    private void ClientConnectThread()
        {
            BluetoothClient client = new BluetoothClient();
            updateUI("attempting connect");
            //client.BeginConnect(deviceInfo.DeviceAddress, mUUID, this.BluetoothClientConnectCallback, client);
            BluetoothAddress addressSeleccionado = deviceInfo.DeviceAddress;
            Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
            BluetoothEndPoint ep = new BluetoothEndPoint(addressSeleccionado, mUUID);
            client.Connect(ep);
            updateUI("connected");
            Stream stream = client.GetStream();
            while (true)
            {
                byte[] received = new byte[1024];
                stream.Read(received, 0, received.Length);
                updateUI("received: ");
                for (int i = 0; i < 15; i++)
                {
                    updateUI(received[i].ToString());
                }
                if (ready)
                {
                    ready = false;
                    stream.Write(message, 0, message.Length);
                }
            }
        }
