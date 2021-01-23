        public void Resume()
        {
            if (!client.IsConnected) {
                client.Connect();
                WearableClass.MessageApi.AddListener(client, this);
                WearableClass.DataApi.AddListener(client, this);
            }
        }
        public void Pause()
        {
            if (client != null && client.IsConnected) {
                client.Disconnect();
                WearableClass.MessageApi.RemoveListener(client, this);
                WearableClass.DataApi.RemoveListener(client, this);
            }
        }
