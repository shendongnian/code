    public class Point2D
    {
        // made this type so i have more control of what i legal to add
        // idea from here: http://stackoverflow.com/questions/424366/c-sharp-string-enums
        public sealed class PointType
        {
            private int type;
            private string name;
    
            public static readonly PointType SETPOINT = new PointType(0, "SETPOINT");
            public static readonly PointType FEEDBACK = new PointType(1, "FEEDBACK");
            public static readonly PointType ESTIMATE = new PointType(2, "ESTIMATE");
    
            private PointType(int Type, string Name)
            {
                this.type = Type;
                this.name = Name;
            }
    
            public override String ToString() 
            { 
                return name; 
            }
        }
    
        public String Type { get; private set; }
        public double Value { get; private set; }
        public DateTime DateTime { get; private set; }
    
        public Point2D( double value, DateTime datetime, Point2D.PointType type)
        {
            Value = value;
            DateTime = datetime;
            Type = type.ToString();
        }
    }
    
    public class Engine
    {
        public Engine(string Name)
        {
            this.Name = Name;
            Datapoints = new List<Point2D>();
    
            foreach(int i in Enumerable.Range(0,101))
            {
                DateTime dt = DateTime.Now;
                double d = i / 100.0;
                Datapoints.Add(new Point2D(d, dt.AddSeconds(i),Point2D.PointType.SETPOINT));
                Datapoints.Add(new Point2D(d, dt.AddSeconds(i+5),Point2D.PointType.FEEDBACK));
                Datapoints.Add(new Point2D(d, dt.AddSeconds(i + 2), Point2D.PointType.ESTIMATE));
            }
        }
        public string Name { get; private set; }
        public List<Point2D> Datapoints { get; private set; }
    }
