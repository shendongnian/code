    public abstract class Abs
    {
        public int Data { get; set; }
    }
    public class A : Abs{}
    public class B : Abs{}
    [Serializable]
    [XmlRoot(elementName: "name")]
    public class Ser
    {
        [XmlElement(elementName: "A")]
        public List<A> AList { get; set; }
        [XmlElement(elementName: "B")]
        public List<B> BList { get; set; }
        [XmlIgnore]
        public List<Abs> AbsList {
            get
            {
                var list = new List<Abs>(AList.ConvertAll(x=>(Abs)x));
                list.AddRange(BList.ConvertAll(x=>(Abs)x));
                return list;
            }
        }
    }
