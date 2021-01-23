    public class MyPipeline : XSocketPipeline
    {
        //Incomming textmessage
        public override void OnMessage(IXSocketController controller, ITextArgs e)
        {
            Console.WriteLine("IN " + e.data);
            //Let the message continue into the server
            base.OnMessage(controller, e);
        }
        //Outgoing textmessage
        public override ITextArgs OnSend(IXSocketProtocol protocol, ITextArgs e)
        {
            Console.WriteLine("OUT " + e.data);
            return base.OnSend(protocol, e);
        }        
    }
