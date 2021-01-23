    public class Client
    {
        public string ProcessRequest(string action, string message)
        {
            IProcessMessage processor = MessageProcessorFactory.Instance.GetProcessor(action);
            return processor.ProcessMessage(message);
        }
    }
