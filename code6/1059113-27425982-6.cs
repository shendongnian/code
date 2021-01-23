    void Main()
    {
        var doc = XDocument.Parse(GetData());
    
        var People =
        doc.Descendants(eOperationType.Person.ToString() )
           .Select (ele => XmlOperations.GetData<Person>(ele, eOperationType.Person));
    
        People.Dump();
    
    }
    
    public static class XmlOperations
    {
        public static T GetData<T>(XElement data, eOperationType target) where T : IOperation
        {
            var clone = Activator.CreateInstance<T>();
    
            clone.ProcessXml(data);
    
            return clone;
        }
    }
    
    
    public class Person : IOperation
    {
        public string FullName { get; set; }
        public eOperationType OpType { get { return eOperationType.Person; } }
        public void ProcessXml(XElement node)
        {
            var attr = node.Attributes().First (atr => atr.Name == "Name");
            FullName = attr.Value.ToString();
        }
    
    }
    
    
    
    // Define other methods and classes here
    public string GetData()
    {
    return @"<Data>
    <Locations>
        <Location Name=""California"">
            <Location Name=""Los Angeles"">
                <Person Name=""Harrison Ford""/>
            </Location>
        </Location>
    </Locations>
    
    <People>
        <Person Name=""Jake Gyllenhaal"" Location=""Los Angeles""/>
    </People>
    </Data>";
    }
    
    
    public enum eOperationType
    {
        Person,
        Location
    };
    
    
    public interface IOperation
    {
        string FullName { get; set; }
        eOperationType OpType { get; }
        void ProcessXml(XElement node);
    }
    
    public interface IPerson : IOperation
    {
    
    }
    
    public interface ILocation : IOperation
    {
    
    }
