    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Xml.XPath;
    namespace StackOverflow
    {
        public static class ObjectStringer
        {
            public static string Stringify<T>(this T obj)
            {
                var xs = new XmlSerializer(obj.GetType());
                var doc = new XDocument();
                using (var writer = doc.CreateWriter())
                {
                    xs.Serialize(writer, obj);
                }
                var s = from text in doc.XPathSelectElements("//*[./text()]") select text.Value;
                return string.Join("|", s);
            }
        }
        public class Field
        {
            static int x = 0;
            int y;
            public Field()
            {
                y = ++x;
            }
            public override string ToString()
            {
                return y.ToString();
            }
            public static implicit operator String(Field f)
            {
                return f==null?null:f.ToString();
            }
            public static implicit operator Field(String s)
            {
                return s ?? "nasty hack to make serializer work";
            }
        }
        public class Demo
        {
            public string P1 { get; set; }
            public string X { get; set; } //something to show if we're pulling back results in order defined here, or if the system just goes alphabetically
            public string P2 { get; set; }
            public int P3 { get; set; }
            public DateTime P4 { get; set; }
        
            public Demo P5 { get; set; }
            [XmlElement(typeof(String))]
            public Field P6 { get; set; }
            [XmlElement(typeof(String))]
            public Field P7 { get; set; }
            public override string ToString()
            {
                return this.Stringify();
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Demo d = new Demo() { P1 = "test1", X = "expert mode", P2 = "test2", P3 = 3, P4 = DateTime.UtcNow, P5 = new Demo() { P1 = "baby", P2 = "ooh" },P6=new Field(),P7=new Field() };
                //d.P5 = d; //this solution's not perfect - e.g. attempt to serialize a circular loop in the object's graph
                Console.WriteLine(d.ToString());
                Console.WriteLine("done");
                Console.ReadKey();
            }
        }
    }
