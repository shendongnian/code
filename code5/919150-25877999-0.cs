        public static FaultException ParseProtocolException(System.ServiceModel.ProtocolException ex) {
            var stream = (ex.InnerException as System.Net.WebException).Response.GetResponseStream();
            try {
                var xmr = XmlReader.Create(stream);
                var message = Message.CreateMessage(xmr, (int)stream.Length, MessageVersion.Soap12);
                var mf = MessageFault.CreateFault(message, (int)stream.Length);
                message.Close();
                return new FaultException(mf);
            } catch (CommunicationException) {    // If CreateMessage has a problem parsing the XML,
                // then this error will be thrown.  Most likely, there is an unresolvable namespace reference.
                // Do an alternate parse
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                var soapFault = GetSoapFault(stream);
                return new FaultException(soapFault.Reason);
            }
        }
