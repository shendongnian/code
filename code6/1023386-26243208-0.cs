    MessageQueue  msMq = new MessageQueue(MQPath);
    msmq.Send(sb.tostring());
    Message[] msgs = msMq.GetAllMessages();
    foreach (var msg in msgs)
          {
                System.IO.StreamReader reader = new System.IO.StreamReader(msg.BodyStream);
                MSGtext = reader.ReadToEnd();
                string MSGValue = (string)XmlDeserializeFromString(MSGtext);
            }
     }
     public object XmlDeserializeFromString(string objectData)
        {
            var serializer = new XmlSerializer(typeof(string));
            object result;
            using (TextReader reader = new StringReader(objectData))
            {
                result = serializer.Deserialize(reader);
            }
            return result;
        }
