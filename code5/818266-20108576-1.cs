        public ProtocolResult Result
        {
            get
            {
                if (_data == null || _header != ResultHeaderValue)
                    return null;
                return _data.ToObject<ProtocolResult>();
            }
        }
        public ProtocolError Error
        {
            get
            {
                if (_data == null || _header != ErrorHeaderValue)
                    return null;
                return _data.ToObject<ProtocolError>();
            }
        }
