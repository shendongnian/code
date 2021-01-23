    public static class MyConfig
    {
        public static string Sender { get; set; }
        public static DoSomethingWithEmail EmailReceivedCallback { get; set; }
    
        public static void BuildMyConfig(string theSender, string theRecipient,
                DoSomethingWithEmail callback)
        {
            Sender = theSender;
            EmailReceivedCallback = callback;
        }
    }
    
    //  Make sure you bring the delegate outside of the Monitoring class!
    public delegate void DoSomethingWithEmail(string theContents);
