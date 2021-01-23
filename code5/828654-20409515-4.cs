    public class Shared
    {
        public virtual string String1 { get { return "Shared's string"; } }
    }
    
    public class ImplementedOne : Shared
    {
        public override string String1 { get { return "ImplementedOne's string"; } }
    }
    
    public class ImplementedTwo : Shared
    {
        public override string String1 { get { return "ImplementedTwo's string"; } }
    }
