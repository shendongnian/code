    private void button4_Click(object sender, EventArgs e)
        {
            using (var context = ZmqContext.Create())
            {
                using (ZmqSocket SubscriberSocket = context.CreateSocket(SocketType.SUB))
                {
                    SubscriberSocket.Subscribe(Encoding.UTF8.GetBytes("220.20"));
                    SubscriberSocket.Connect("tcp://127.0.0.1:5000");
                    while(true)
                    {
                      var message = SubscriberSocket.Receive(Encoding.UTF8);
                      UpdatetextBox(message);
                    }
                }
            }
        }
