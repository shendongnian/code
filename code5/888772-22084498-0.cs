    using System.Dynamic;
    using System.Xml.Linq;
        protected Car ParseXml(Car NewCar) {          
            string xml = "<?xml version=\"1.0\"?><somerootname1>  <car>    <make>honda</make>    <model>civic</model>  </car></somerootname1>";            
            dynamic car = DynamicXml.Parse(xml);            
            NewCar.Make = car.car.make;
            NewCar.Model = car.car.model;
            return NewCar;
        }
    [Serializable]
    public partial class Car
    {
        public Car() { }
      
        public string Make { get; set; }
      
        public string Model { get; set; }
    }
    public class DynamicXml : DynamicObject
    {
        XElement _root;
        private DynamicXml(XElement root)
        {
            _root = root;
        }
    
        public static DynamicXml Parse(string xmlString)
        {
            return new DynamicXml(XDocument.Parse(xmlString).Root);
        }
    
        public static DynamicXml Load(string filename)
        {
            return new DynamicXml(XDocument.Load(filename).Root);
        }
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
    
            var att = _root.Attribute(binder.Name);
            if (att != null)
            {
                result = att.Value;
                return true;
            }
    
            var nodes = _root.Elements(binder.Name);
            if (nodes.Count() > 1)
            {
                result = nodes.Select(n => new DynamicXml(n)).ToList();
                return true;
            }
    
            var node = _root.Element(binder.Name);
            if (node != null)
            {
                if (node.HasElements)
                {
                    result = new DynamicXml(node);
                }
                else
                {
                    result = node.Value;
                }
                return true;
            }
    
            return true;
        }
    }
