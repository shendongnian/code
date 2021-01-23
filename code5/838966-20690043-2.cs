    [Serializable] public class WSExecCommand
    {
        public string Command;
    
        [XmlIgnore] public Dictionary<string, MyKeyValuePair> __ParentKey = 
             new Dictionary<string, MyKeyValuePair>();
        [XmlArray] public List<MyKeyValuePair> ParentKey
        { 
            get
            {
                return new List<KeyValuePair>(__ParentKey.Values); 
            }
            set
            {
                __ParentKey.Clear();
                foreach (MyKeyValuePair kvp in value)
                    __ParentKey.Add(kvp.Key, kvp);
            }
        }
    }
