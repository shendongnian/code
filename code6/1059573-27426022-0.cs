    namespace FlightSim
    {
        public class Flight
        {
            *snip*
            public event System.EventHandler LogMessage; //<--creates an uninitialized eventhandler
            *snip*
            protected void OnLogUpdate(string logMessage)
            {
                if (logMessage == "")
                    return;
    
                MessageEventArgs e = new MessageEventArgs();
                var handler = LogMessage; //<== sets handler to uninitialized logmessage?
    
                if (handler != null)
                {
                    e.msgContent = logMessage;
                    handler(this, e);
                }
            }
        }
    }
