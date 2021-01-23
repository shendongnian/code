    public class MyService: IMyService
    {
        public void OnMessage(Message msg)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyCallback>();
            if (msg.IsEmpty || ((IChannel)callback).State != CommunicationState.Opened)
            {
                return;
            }
            byte[] messageBody = msg.GetBody<byte[]>();
            string messageString = Encoding.UTF8.GetString(messageBody);
        
            ...
            callback.Reply(CreateMessage(responseString));
        }
    
        private Message CreateMessage(string messageString)
        {
            var messageBody = new ArraySegment<byte>(Encoding.UTF8.GetBytes(messageString));
            Message msg = ByteStreamMessage.CreateMessage(messageBody);
            msg.Properties["WebSocketMessageProperty"] = new WebSocketMessageProperty 
            { 
                MessageType = WebSocketMessageType.Text 
            };
            return msg;
        }
    } 
