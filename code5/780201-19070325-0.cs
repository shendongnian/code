    public class MySystem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
    
        public MyMonitor[] Monitors { get; private set; }
    
        public MySystem(XElement x)
        {
            Id = (int)x.Element("ID");
            Name = x.Element("Name").Value;
            // a little confusing from your code if there can be more than one Monitor
            Monitors = x.Elements("Monitor").Select(m => new MyMonitor(m)).ToArray();
        }
    }
