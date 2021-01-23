    [ProtoContract]
    public class MyClass {
        public ConcurrentQueue<Point3DCollection> Points {get;set;}
        [ProtoMember(1)]
        private Point3DCollection[] Items
        {
            get { return Points.ToArray(); }
            set { Items = new ConcurrentBag<Point3DCollection>(value); }
        }
    }
