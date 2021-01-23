    messageQueue.Formatter = new XmlMessageFormatter(
      new Type[] { typeof(System.Xml.XmlElement) });
    MessageEnumerator iter = messageQueue.GetMessageEnumerator2();
    iter.Reset();
    while (iter.MoveNext(new TimeSpan(1000)))
    {
        System.Messaging.Message msg = iter.Current;
        msg.Formatter = new ActiveXMessageFormatter();
        var reader = new StreamReader(msg.BodyStream);
        var msgBody = reader.ReadToEnd();
    }
