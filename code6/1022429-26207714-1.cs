    public class DataHolder
    {
        object lockObj = new object();
        private XmlDocument _xmlDoc;
        public XmlDocument XmlDoc
        { 
          get{return GetXmlDoc();}
          set{SetXmlDoc(value);}
        }
       
        private XmlDocument GetXmlDoc()
        {
           lock(lockObj) return _xmlDoc;
        }
    
        private void SetXmlDoc(XmlDocument xmlDoc)
        {
           lock(lockObj) _xmlDoc = xmlDoc;
        }
    }
    public class AccessClass
    {
        DataHolder dataHolderInstance;
    
        public AccessClass(DataHolder _dataHolder)
        {
            dataHolderInstance = _dataHolder;
        }
    
        private void CreateXmlDoc()
        {
            XmlDocument _xmlDoc = new XmlDocument();
            dataHolderInstance.XmlDoc = _xmlDoc;
        }
    
        private void ReadXmlDoc()
        {
            XmlNodeList elemList = dataHolderInstance.XmlDoc.GetElementsByTagName("title");
        }
     }
