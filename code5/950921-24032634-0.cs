    public abstract class SelfReferencing
    {
        public SelfReferencing Parent { get; set; }
        public ICollection<SelfReferencing> Children { get; set; }
    }
    
    public class ConcreteSelfReferencing : SelfReferencing
    {
    }
