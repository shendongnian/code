        public void OnMessageReceived(IMessageEvent messageEvent)
        {
            var message = Encoding.Default.GetString(messageEvent.GetData());
            Console.WriteLine(string.Format("Communicator: Message received \"{0}\"", message));
            MessageReceived(message);
        }
        public void OnDataChanged(DataEventBuffer p0)
        {
            Console.WriteLine(string.Format("Communicator: Data changed ({0} data events)", p0.Count));
            for (var i = 0; i < p0.Count; i++) {
                var dataEvent = p0.Get(i).JavaCast<IDataEvent>();
                if (dataEvent.Type == DataEvent.TypeChanged && dataEvent.DataItem.Uri.Path == path)
                    DataReceived(DataMapItem.FromDataItem(dataEvent.DataItem).DataMap);
            }
        }
