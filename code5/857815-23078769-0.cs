    public class SoapLoggingExtension : SoapExtension
    {
        private Stream _originalStream;
        private Stream _workingStream;
        private static String _initialMethodName;
        private static string _methodName;
        private static String _xmlResponse;
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
        /// Process soap message
        /// </summary>
        /// <param name="message"></param>
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    //Get soap call as a xml string
                    var xmlRequest = GetSoapEnvelope(_workingStream);
                    //Save the inbound method name
                    _methodName = message.MethodInfo.Name;
                    CopyStream(_workingStream, _originalStream);
                    //Log call
                    LogSoapRequest(xmlRequest, _methodName, LogObject.Direction.OutPut);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    CopyStream(_originalStream, _workingStream);
                    //Get xml string from stream before it is used
                    _xmlResponse = GetSoapEnvelope(_workingStream);
                    break;
                case SoapMessageStage.AfterDeserialize:
                    //Method name is only available after deserialize
                    _methodName = message.MethodInfo.Name;
                    LogSoapRequest(_xmlResponse, _methodName, LogObject.Direction.InPut);
                    break;
            }
        }
        /// <summary>
        /// Returns the XML representation of the Soap Envelope in the supplied stream.
        /// Resets the position of stream to zero.
        /// </summary>
        private String GetSoapEnvelope(Stream stream)
        {
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            stream.Position = 0;
            return data;
        }
        private void CopyStream(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
        public override object GetInitializer(Type serviceType)
        {
            return serviceType.FullName;
        }
        //Never needed to use this initializer, but it has to be implemented
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            throw new NotImplementedException();
            //return ((TraceExtensionAttribute)attribute).Filename;
        }
        public override void Initialize(object initializer)
        {
            if (String.IsNullOrEmpty(_methodName))
            {
                _initialMethodName = _methodName;
                _waitForResponse = false;
            }
        }
        private void LogSoapRequest(String xml, String methodName, LogObject.Direction direction)
        {
            String connectionString = String.Empty;
            String callerIpAddress = String.Empty;
            String ipAddress = String.Empty;
            try
            {
                //Only log outbound for the response to the original call
                if (_waitForResponse && xml.IndexOf("<" + _initialMethodName + "Response") < 0)
                {
                    return;
                }
                if (direction == LogObject.Direction.InPut) {
                    _waitForResponse = true;
                    _initialMethodName = methodName;
                }
                connectionString = GetSqlConnectionString();
                callerIpAddress = GetClientIp();
                ipAddress = GetClientIp(HttpContext.Current.Request.UserHostAddress);
                //Log call here
                if (!String.IsNullOrEmpty(_methodName) && xml.IndexOf("<" + _initialMethodName + "Response") > 0)
                {
                    //Reset static values to initial
                    _methodName = String.Empty;
                    _initialMethodName = String.Empty;
                    _waitForResponse = false;
                }
            }
            catch (Exception ex)
            {
                //Error handling here
            }
        }
        private static string GetClientIp(string ip = null)
        {
            if (String.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if (String.IsNullOrEmpty(ip) || ip.Equals("unknown", StringComparison.OrdinalIgnoreCase))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (ip == "::1")
                ip = "127.0.0.1";
            return ip;
        }
    }
