    public class parent {
        [XmlArray("child")]
        [XmlArrayItem("mychild")]
        public List<child> myChilds { get; set;}
        public string parmem {get; set;}
        public parent() {
            parmem = "I AM PARENT" ;
            myChilds = new List<child>();
            myChilds.Add(new child() {mem  = "I AM  CHILD"} ); 
        }
    }
