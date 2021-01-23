            StringBuilder sb = new StringBuilder();
             sb.Append("Person Message");
             sb.Append("<?XML Version=\"1.0\">");
             sb.Append("<Person>");
             sb.Append("<Employee>");
             sb.Append("<Name>Manthan</Name>");
             sb.Append("</Employee>");
             sb.Append("</Person>");
             //write to Queue
             msMq.Formatter = new ActiveXMessageFormatter();
             msMq.Send(sb.ToString());
             //read From Queue
            MessageQueue  msMqReader = new MessageQueue(MQPath);
            msMqReader.Formatter = new CustomeMessageFormatter();
            Message[] msgs = msMqReader.GetAllMessages();
            string MSGtext;
            
            foreach (var msg in msgs)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(msg.BodyStream);
                MSGtext = reader.ReadToEnd();            
            }
         }
