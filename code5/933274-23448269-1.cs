    public class MyPair
    {
        public readonly XElement element;
        
        public MyPair(XElement element){ this.element = element; }
    
        public string[] Adapters
        { 
             get 
             { 
                 return _Adapters ?? (_Adapters = element.Descendants("CommandText")
                                                         .Select(ct => (string)ct)
                                                         .ToArray());
             }
        } 
        string[] _Adapters;
    
    
        public string[] Members
        { 
             get 
             { 
                 return _Members ?? (_Members = element.Descendants("DataMember")
                                                       .Select(dm => (string)dm)
                                                       .ToArray());
             }
        } 
        string[] _Members;  
    }
