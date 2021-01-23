    public class SoapLoggingExtension : SoapExtension
    {
        private Stream _originalStream;
        private Stream _workingStream;
        private string _methodName;
        private List<KeyValuePair<string, string>> _parameters;
        private XmlDocument _xmlResponse;
        private string _url;
        /// <summary>
        /// Side effects: saves the incoming stream to
        /// _originalStream, creates a new MemoryStream
        /// in _workingStream and returns it.  
        /// Later, _workingStream will have to be created
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public override Stream ChainStream(Stream stream)
        {
            _originalStream = stream;
            _workingStream = new MemoryStream();
            return _workingStream;
        }
        /// <summary>
        /// AUGH, A TEMPLATE METHOD WITH A SWITCH ?!?
        /// Side-effects: everywhere
        /// </summary>
        /// <param name="message"></param>
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    var xmlRequest = GetSoapEnvelope(_workingStream);
                    CopyStream(_workingStream, _originalStream);
                    LogResponse(xmlRequest, GetIpAddress(), _methodName, _parameters); // final step
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    CopyStream(_originalStream, _workingStream);
                    _xmlResponse = GetSoapEnvelope(_workingStream);
                    _url = message.Url;
                    break;
                case SoapMessageStage.AfterDeserialize:
                    SaveCallInfo(message);                    
                    break;
            }
        }
      
        private void SaveCallInfo(SoapMessage message)
        {
            _methodName = message.MethodInfo.Name;
            // the parameter value is converted to a string for logging, 
            // but this may not be suitable for all applications.
            ParameterInfo[] parminfo = message.MethodInfo.InParameters;
            _parameters = parminfo.Select((t, i) => new KeyValuePair<string, String>(
                    t.Name, Convert.ToString(message.GetInParameterValue(i)))).ToList();
        }
        private void LogResponse(
            XmlDocument xmlResponse,
            String ipaddress,
            string methodName, 
            IEnumerable<KeyValuePair<string, string>> parameters)
        {
            // SEND TO LOGGER HERE!
        }
        /// <summary>
        /// Returns the XML representation of the Soap Envelope in the supplied stream.
        /// Resets the position of stream to zero.
        /// </summary>
        private XmlDocument GetSoapEnvelope(Stream stream)
        {
            XmlDocument xml = new XmlDocument();
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            xml.LoadXml(reader.ReadToEnd());
            stream.Position = 0;
            return xml;
        }
        private void CopyStream(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
       
        // GLOBAL VARIABLE DEPENDENCIES HERE!!
        private String GetIpAddress()
        {
            try
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception)
            {
                // ignore error;
                return "";
            }
        }
