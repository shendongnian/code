    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", 
                                                      "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Room", 
                 Namespace="http://schemas.datacontract.org/2004/07/DummyService")]
    public partial class Room : object,
                    System.Runtime.Serialization.IExtensibleDataObject
    {        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;        
        private uint RoomIdField;        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public uint RoomId
        {
            get
            {
                return this.RoomIdField;
            }
            set
            {
                this.RoomIdField = value;
            }
        }
    }
