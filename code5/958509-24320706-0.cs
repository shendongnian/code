        public setDataRequest() 
        {
            ConnectionInfo = Base.Service.Configuration.DefaultConnectionInfo;
        }
        [MessageBodyMember(Order = 0, Name = "connectionInfo")]
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ConnectionInfo ConnectionInfo { get; set; }
        [MessageBodyMember(Order = 1, Name = "generic")]
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public GenericSet Generic { get; set; }
    }
