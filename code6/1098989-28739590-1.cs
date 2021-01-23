    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog{Name = "Ernie", HasFleas = true},
                new Cat{ Name = "Bert", Collar = "Blue with a little bell" }
            };
            XDocument doc = new XDocument();
            doc.Declaration = new XDeclaration("1.0","utf-8","true");
            doc.Add(new XElement("root", animals.Select(animal => animal.GetElement)));
            
            Console.WriteLine(doc);
        }
    }
   
    public abstract class Animal 
    {
        [XmlAttribute]
        public string Name { get; set; }
        public XElement GetElement 
        {
            get 
            {
                Type type = this.GetType();
                XElement result = new XElement(type.Name);
                foreach (PropertyInfo property in
                    type.GetProperties().Where(pi=> pi.CustomAttributes.Any(ca=> ca.AttributeType == typeof(System.Xml.Serialization.XmlAttributeAttribute))))
                {
                    result.Add(new XAttribute(property.Name,property.GetValue(this)));
                }
                foreach (PropertyInfo property in
                    type.GetProperties().Where(pi => pi.CustomAttributes.Any(ca => ca.AttributeType == typeof(System.Xml.Serialization.XmlElementAttribute))))
                {
                    result.Add(new XElement(property.Name,property.GetValue(this)));
                }
                return result;
            }
        }
    }
    
    public class Dog : Animal 
    { 
        [XmlAttribute]
        public bool HasFleas { get; set; }
    }
    public class Cat : Animal 
    {
        [XmlElement]
        public string Collar { get; set; }
    }
