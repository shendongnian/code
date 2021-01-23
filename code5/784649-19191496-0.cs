    //Simplest EventAggregator
    public static class DumbAggregator
    {
        public static void BroadCast(string message)
        {
           if (OnMessageTransmitted != null)
               OnMessageTransmitted(message);
        }
        
        public static Action<string> OnMessageTransmitted;
    }
