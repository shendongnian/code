    MessageQueue mq = new MessageQueue(@".\private$\<YourQueue>");
    using (MessageQueueTransaction mqt = new MessageQueueTransaction())
            {
                mqt.Begin();
                message = new Message();                    
                message.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
                message.Body = JsonConvert.SerializeObject(<YourJsonObject>);
                mq.Send(message, mqt);
                mqt.Commit();
            }
