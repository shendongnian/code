    [DataContract]
        public abstract class DomainBase
        {
            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            [DataMember]
            [Key]
            public long Id { get; set; }
    
            
            private byte[] _timestamp=new Guid().ToByteArray();
    
            /// <summary>
            /// Gets or sets the timestamp.
            /// </summary>
            [DataMember]
            public byte[] Timestamp { get { return _timestamp; }
                set { _timestamp = value;
                if (_timestamp != null && _signature != Convert.ToBase64String(_timestamp))
                        _signature = Convert.ToBase64String(_timestamp);
                }
            }
    
            private string _signature = Convert.ToBase64String(new Guid().ToByteArray());
    
            /// <summary>
            /// Gets the signature.
            /// </summary>
            [DataMember]
            public string Signature
            {
                get { return _signature ?? (Timestamp != null ? _signature = Convert.ToBase64String(Timestamp) : null); }
                protected set { _signature = value;
                    if ((_timestamp == null && !String.IsNullOrWhiteSpace(_signature)) ||
                        (_timestamp != null && !String.IsNullOrWhiteSpace(_signature) && Convert.ToBase64String(_timestamp) != _signature))
                        _timestamp = Convert.FromBase64String(value);
                }
            }
    
            /// <summary>
            /// Gets a value indicating whether has signature.
            /// </summary>
            public bool HasSignature
            {
                get { return Timestamp != null; }
            }
        }
