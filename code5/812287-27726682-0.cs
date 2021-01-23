    using System;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;
    namespace NoNamespaceXml
    {
      public class GenericSerializer : XmlObjectSerializer
      {        
        #region Private Variables
        private XmlSerializer serializer;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a GenericSerializer  
        /// </summary>
        /// <param name="objectToSerialize"></param>
        public GenericSerializer (object objectToSerialize)
        {
            // If the objectToSerialize object exists
            if (objectToSerialize != null)
            {
                // Create the Serializer
                this.Serializer = new XmlSerializer(objectToSerialize.GetType());
            }
        }
        #endregion
        
        #region Methods
            
            #region IsStartObject(XmlDictionaryReader reader)
            /// <summary>
            /// This method Is Start Object
            /// </summary>
            public override bool IsStartObject(XmlDictionaryReader reader)
            {
                throw new NotImplementedException();
            }
            #endregion
            
            #region ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
            /// <summary>
            /// This method Read Object
            /// </summary>
            public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
            {
                throw new NotImplementedException();
            }
            #endregion
            
            #region WriteEndObject(XmlDictionaryWriter writer)
            /// <summary>
            /// This method Write End Object
            /// </summary>
            public override void WriteEndObject(XmlDictionaryWriter writer)
            {
                throw new NotImplementedException();
            }
            #endregion
            
            #region WriteObject(XmlDictionaryWriter writer, object graph)
            /// <summary>
            /// This method Write Object
            /// </summary>
            public override void WriteObject(XmlDictionaryWriter writer, object graph)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, graph, ns);
            }
            #endregion
            
            #region WriteObjectContent(XmlDictionaryWriter writer, object graph)
            /// <summary>
            /// This method Write Object Content
            /// </summary>
            public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
            {
                throw new NotImplementedException();
            }
            #endregion
            
            #region WriteStartObject(XmlDictionaryWriter writer, object graph)
            /// <summary>
            /// This method Write Start Object
            /// </summary>
            public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
            {
                throw new NotImplementedException();
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region HasSerializer
            /// <summary>
            /// This property returns true if this object has a 'Serializer'.
            /// </summary>
            public bool HasSerializer
            {
                get
                {
                    // initial value
                    bool hasSerializer = (this.Serializer != null);
                    
                    // return value
                    return hasSerializer;
                }
            }
            #endregion
          
            #region Serializer
            /// <summary>
            //  This property gets or sets the value for 'Serializer'.
            /// </summary>
            public XmlSerializer Serializer
            {
                get { return serializer; }
                set { serializer = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion
