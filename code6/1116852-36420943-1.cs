        private void _tcpClient_DataReceived(byte[] data)
        {
            var rawMsg = Encoding.Unicode.GetString(data);
            var normalizedMessages = NormalizeMessage(rawMsg);
            foreach (var normalizedMessage in normalizedMessages)
            {
                //TODO: your logic
            }
        }
