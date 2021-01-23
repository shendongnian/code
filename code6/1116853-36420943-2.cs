        private object _dataReceiverLock = new object();
        private string _messageBuffer;
        private Stopwatch _timeSinceLastMessage = new Stopwatch();
        private List<string> NormalizeMessage(string rawMsg)
        {
            lock (_dataReceiverLock)
            {
                List<string> result = new List<string>();
                //following code prevents buffer to store too old information
                if (_timeSinceLastMessage.ElapsedMilliseconds > _settings.ResponseTimeout)
                {
                    _messageBuffer = string.Empty;
                }
                _timeSinceLastMessage.Restart();
                foreach (var ch in rawMsg)
                {
                    _messageBuffer += ch;
                    if (ch == '>')//to avoid extra checks
                    {
                        if (IsValidXml(_messageBuffer))
                        {
                            result.Add(_messageBuffer);
                            _messageBuffer = string.Empty;
                        }
                    }
                }
                return result;
            }
        }
        private bool IsValidXml(string xml)
        {
            try
            {
                //fastest way to validate XML format correctness
                using (XmlTextReader reader = new XmlTextReader(new StringReader(xml)))
                {
                    while (reader.Read()) { }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
