    public interface INonGen
    {
        object Value { get; }
    }
    
    public interface IGen<U> : INonGen
    {
    }
    
    public class Gen<U> : IGen<U>
    {
        private U u;
        public object Value
        {
           get { return u; }
        }
    }
