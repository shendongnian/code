    class JoinedChannelEventArgs : EventArgs
    {
        public Channel Channel { get; private set; }
        public JoinedChannelEventArgs(Channel channel) { Channel = channel; }
    }
    class A
    {
        public static event EventHandler<JoinedChannelEventArgs> JoinedChannel;
        private static void LocalUser_JoinedChannel(object sender, IrcChannelEventArgs e)
        {
            e.Channel.MessageReceived += Channel_MessageReceived;
            Console.WriteLine("Joined " + e.Channel + "\n");
            EventHandler<JoinedChannelEventArgs> handler = JoinedChannel;
            if (handler != null)
            {
                handler(null, new JoinedChannelEventArgs(e.Channel);
            }
        }
    }
    class B
    {
        static void SomeMethod()
        {
            A.JoinedChannel += A_JoinedChannel;
        }
        private static void A_JoinedChannel(object sender, JoinedChannelEventArgs e)
        {
            e.Channel += MessageReceivedHangman;
        }
    }
