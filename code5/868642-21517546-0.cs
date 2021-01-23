    public void SocketExample(IPEndPoint endPoint) {
        Socket sender = new Socket(AddressFamily.InterNetwork, 
                    SocketType.Stream, ProtocolType.Tcp);
    
        Socket.Connect(endPoint);
        byte[] message1 = Encoding.ASCII.GetBytes("These might be arrive");
        byte[] message2 = Encoding.ASCII.GetBytes(" in the same packet!");
        sender.Send(message1);
        sender.Send(message2);
    }
