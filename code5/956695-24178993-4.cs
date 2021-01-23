    [Serializable]
    public class MyClass
    {
        private TimeSpan executionTime = TimeSpan.FromSeconds(0.0);
        [System.Xml.Serialization.XmlIgnore] 
        public TimeSpan ExecutionTime
        {
            get {return executionTime;}
            set {executionTime = value;}
        }
        public double ExecutionTimeSeconds
        {
            get {return executionTime.TotalSeconds;}
            set {executionTime = TimeSpan.FromSeconds(value);}
        }
    }
