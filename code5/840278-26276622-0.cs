    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class MyCustomMsmqTraceListener : CustomTraceListener
    {
        public override void Write(object o)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, o);
            string serializedMessage = new StreamReader(ms).ReadToEnd();
            this.Write(serializedMessage);
        }
        public override void Write(string message)
        {
            SendMessageToQueue(message);
        }
        public override void WriteLine(string message)
        {
            SendMessageToQueue(message);
        }
        private void SendMessageToQueue(string message)
        {
            string queueName = @".\Private$\test";
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName);
            MessageQueue mq = new MessageQueue(queueName, QueueAccessMode.Send);
            mq.Label = DateTime.Now.ToString();
            mq.Send(message);
            mq.Close();
        }
    }
