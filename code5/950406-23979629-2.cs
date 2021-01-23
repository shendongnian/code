    //threadsafe queue
    private readonly ConcurrentQueue<byte[]> queue = new ConcurrentQueue<byte[]>();
    private void SendButton_Click(object sender, EventArgs e)
    {
        //queue it up
        queue.Enqueue(SerializeData(ShapeList[ShapeList.Count - 1]));
    }
    void connect()
    {
        try
        {            
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
            client.Connect(iep);
            while (true)
            {
                byte[] data = new byte[1024];
                var received = client.Receive(data);
                if(received > 0)
                { //careful, how do you know you have it all?
                  PaintObject a = (PaintObject)DeserializeData(data);
                  ShapeList.Add(a);
                  Invalidate();
                }
                while(!queue.IsEmpty)
                {
                   //queue dequeue and send
                   client.Send(queue.Dequeue());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
