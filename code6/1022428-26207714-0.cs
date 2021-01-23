    public class AccessClass
    {
        DataHolder dataHolderInstance;
    
        object lockObj;
    
        public AccessClass(DataHolder _dataHolder)
        {
            dataHolderInstance = _dataHolder;
            lockObj = new object();
        }
    
        private void CreateXmlDoc()
        {
            Monitor.TryEnter(lockObj, Timeout.Infinite);
            XmlDocument _xmlDoc = new XmlDocument();
            dataHolderInstance.XmlDoc = _xmlDoc;
            Monitor.Exit(lockObj);
        }
    
        private void ReadXmlDoc()
        {
            Monitor.TryEnter(lockObj, Timeout.Infinite);
            XmlNodeList elemList = dataHolderInstance.XmlDoc.GetElementsByTagName("title");
            Monitor.Exit(lockObj);
            //do stuff with elemList..
        }
     }
