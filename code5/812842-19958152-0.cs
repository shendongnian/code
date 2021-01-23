        public enum Protocol
        {
             Http,
             Ftp
        }
        string strProtocolType = GetFromProtocolTypeFromDB();
        Protocol protocolType = (Protocol)Enum.Parse(typeof(Protocol), strProtocolType);
        switch (protocolType)
        {
            case Protocol.Http:
                {
                    break;
                }
            case Protocol.Ftp:
                {
                    break;
                }
        }
