    class A
    {
        public static event EventHandler<IrcMessageEventArgs> AnyChannelMessageReceived;
        public static void Channel_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            // Whatever other code you had here, would remain
            EventHandler<IrcMessageEventArgs> handler = AnyChannelMessageReceived;
            if (handler != null)
            {
                handler(null, e);
            }
        }
    }
    class B
    {
        static void SomeMethod()
        {
            A.AnyChannelMessageReceived += MessageReceivedHangman;
        }
    }
