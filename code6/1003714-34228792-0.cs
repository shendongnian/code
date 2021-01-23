    // Here MyMessage is my class which contain some
    // stuff which I want to pass to MSMQ.
    public void Send(MyMessage myMessage)
    {
        XmlSerializer ser = new XmlSerializer(typeof(MyMessage));
        StringBuilder sb = new StringBuilder();
    
        using (StringWriter writer = new StringWriter())
        {
            ser.Serialize(writer, myMessage);
    
            Debug.WriteLine(writer.ToString());
        }
        Message _myMessage = new Message(myMessage, new BinaryMessageFormatter());
        //_messageQueue is object of MSMQMessage
        lock(_objlck)
        {
            _messageQueue.Send(_myMessage);
        }
     }
