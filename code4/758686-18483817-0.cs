    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    public class Foo
    {
        [XmlElement("area", Order = 2)]
        public virtual string Area { get; set; }
    
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool ShouldSerializeArea()
        {
            return true;
        }
    }
    public class Bar : Foo
    {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool ShouldSerializeArea()
        {
            return false;
        }
    
        [XmlElement("totalArea", Order = 2)]
        public string TotalArea
        {
            get { return Area; }
            set { Area = value; }
        }
    }
    static class Program
    {
        static void Main()
        {
            new XmlSerializer(typeof(Foo)).Serialize(Console.Out, new Foo { Area = "hello" });
            Console.WriteLine();
            new XmlSerializer(typeof(Bar)).Serialize(Console.Out, new Bar { Area = "world" });
        }
    }
