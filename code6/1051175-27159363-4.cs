    [Serializable]
    public class Field
    {
        static int x = 0;
        int y;
        public string DummyToString { get { return this.ToString(); }  set { /*serializer hack*/ } }
        [XmlIgnore]
        public string DontShowMe { get; set; }
            
        public Field()
        {
            y = ++x;
            DontShowMe = "you shouldn't see this";
        }
            
        public override string ToString()
        {
            return string.Format("string me on #{0}", y);
        }
    }
    //Demo's Field properties no longer require XmlElement attributes; i.e.:
    public Field P6 { get; set; }
    public Field P7 { get; set; }
