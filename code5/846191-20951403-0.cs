    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using Microsoft.Exchange.Data.Transport;
    using Microsoft.Exchange.Data.Transport.Routing;
    
    
    
    namespace MyAgents
    {
        public sealed class MyAgentFactory : RoutingAgentFactory
        {
            public override RoutingAgent CreateAgent(SmtpServer server)
            {
                return new MyAgent();
            }
        }
        public class MyAgent : RoutingAgent
        {
            public MyAgent()
            {
                this.OnSubmittedMessage += new SubmittedMessageEventHandler(this.MySubmittedMessageHandler);            
            }
    
            public void MySubmittedMessageHandler(SubmittedMessageEventSource source, QueuedMessageEventArgs e)
            {
                e.MailItem.Message.Subject = "This message passed through my agent: " + e.MailItem.Message.Subject;
            }
        }
    }
