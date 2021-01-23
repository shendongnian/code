      public class MessageTypeInspector : IDispatchMessageInspector
       {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext                 instanceContext)
            {
               RecreateMessage(ref request);
                return null;
            }
       }
 
    private void RecreateMessage(ref Message message)
            {
                WebContentFormat messageFormat = this.GetMessageContentFormat(message);
                var ms = new MemoryStream();
                XmlDictionaryWriter writer = null;
                switch (messageFormat)
                {
                    case WebContentFormat.Default:
                    case WebContentFormat.Xml:
                        writer = XmlDictionaryWriter.CreateTextWriter(ms);
                        break;
                    case WebContentFormat.Json:
                        writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                        break;
                    case WebContentFormat.Raw:
                       this.ReadRawBody(ref message);
                        break;
                }
    
                message.WriteMessage(writer);
                writer.Flush();
                string messageBody = Encoding.UTF8.GetString(ms.ToArray());
    
                if (messageFormat == WebContentFormat.Json && !messageBody.Contains("__type"))
                    messageBody = AddTypeField(messageBody);
               
                ms.Position = 0;
    
              
                ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody));
    
                XmlDictionaryReader reader = messageFormat == WebContentFormat.Json ?
                    JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max) :
                    XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);
    
                Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
                newMessage.Properties.CopyProperties(message.Properties);
                message = newMessage;
    
            }
     private WebContentFormat GetMessageContentFormat(Message message)
            {
                WebContentFormat format = WebContentFormat.Default;
                if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
                {
                    WebBodyFormatMessageProperty bodyFormat;
                    bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                    format = bodyFormat.Format;
                }
    
                return format;
            }
    private string AddTypeField(string jsonReply)
            {
                var typeRegex = new Regex("\"type\":(?<number>[0-9]*)");
    
                Match match = typeRegex.Match(jsonReply);
                if (match.Success)
                {
                    int number = Int32.Parse(match.Groups["number"].Value);
                    var type = (MessageType)number;
                    var nameFormat = string.Format("Bus{0}Message", type);
                    string format = string.Format("\"__type\":\"{0}:#TransportModels.Messages\"", nameFormat);
                    jsonReply = "{" + string.Format("{0},{1}", format, jsonReply.Substring(1));
                    return jsonReply;
                }
                else
                {
                    throw new Exception("Wrong message type.");
                }
            }
