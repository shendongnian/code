        public virtual void SendMessage(string message, string[] data)
        {
            var fields = new List<object>(data);
            using (var record = new Record(fields.ToArray()) { FormatString = message })
            {
                _session.Message(InstallMessage.Warning, record);
            }
        }
