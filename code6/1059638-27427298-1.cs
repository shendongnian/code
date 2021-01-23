    namespace XMLSerializationDemo
    {
        /// <summary>
        /// Object that contains a collection of RUBIObjects which can be serialized into XML
        /// </summary>
        [Serializable]
        public class RUBIObjectCollection
        {
            //Base Constructor which instantiates a collection of RUBIObjects
            public RUBIObjectCollection()
            {
                this.Objects = new List<RUBIObject>();
            }
    
            public List<RUBIObject> Objects { get; set; }
        } 
    }
