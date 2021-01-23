        public void SendMessage(string message)
        {
            Task.Run(() => {
                foreach (var node in Nodes()) {
                    var bytes = Encoding.Default.GetBytes(message);
                    var result = WearableClass.MessageApi.SendMessage(client, node.Id, path, bytes).Await();
                    var success = result.JavaCast<IMessageApiSendMessageResult>().Status.IsSuccess ? "Ok." : "Failed!";
                    Console.WriteLine(string.Format("Communicator: Sending message {0}... {1}", message, success));
                }
            });
        }
        public void SendData(DataMap dataMap)
        {
            Task.Run(() => {
                var request = PutDataMapRequest.Create(path);
                request.DataMap.PutAll(dataMap);
                var result = WearableClass.DataApi.PutDataItem(client, request.AsPutDataRequest()).Await();
                var success = result.JavaCast<IDataApiDataItemResult>().Status.IsSuccess ? "Ok." : "Failed!";
                Console.WriteLine(string.Format("Communicator: Sending data map {0}... {1}", dataMap, success));
            });
        }
