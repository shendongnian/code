    using System.Net;
    using System.Messaging;
    
    MessageQueue[] privatequeuelist = MessageQueue.GetPrivateQueuesByMachine(Dns.GetHostName());
    
 
