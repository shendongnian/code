    string error = "Some error message I want to log";
    using (MessageQueue MQ = new MessageQueue(@".\Private$\Your.Queue.Name"))
    {
        BinaryMessageFormatter formatter = new BinaryMessageFormatter();
        System.Messaging.Message mqMessage = new System.Messaging.Message(error, formatter);
        MQ.Send(mqMessage, MessageQueueTransactionType.Single);
        MQ.Close();
    }
