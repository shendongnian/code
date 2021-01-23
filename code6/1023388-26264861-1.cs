            StringBuilder sb = new StringBuilder();
             sb.Append("Person Message");
             sb.Append("<?XML Version=\"1.0\">");
             sb.Append("<Person>");
             sb.Append("<Employee>");
             sb.Append("<Name>Manthan</Name>");
             sb.Append("</Employee>");
             sb.Append("</Person>");
             msMq.Formatter = new CustomeMessageFormatter();
             msMq.Send(sb.ToString());
            Message[] msgs = msMq.GetAllMessages();
            string MSGtext;
            
            foreach (var msg in msgs)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(msg.BodyStream);
                MSGtext = reader.ReadToEnd();            
            }
         }
