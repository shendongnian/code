    public class Monitoring
    {
        public void StartMonitoring()
        {
            const string receivedEmail = "New Answer on your SO Question!";
    
            //Invoke the callback assigned to the config class
            MyConfig.EmailReceivedCallback(receivedEmail);
        }
    }
