    public abstract class BaseClass {
        //Used for second example of custom type lookup
        public abstract string Type { get; set; }
    }
    
    public class ChildA : BaseClass {
        //Used for second example of custom type lookup
        public override string Type { get; set; }
        public string PropA { get; set; }
    }
