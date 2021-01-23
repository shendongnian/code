    public abstract class Gift
    {
        public IWrappingStyle wrapping { get; private set; }
        public Gift(IWrappingStyle wrapping)
        {
            this.wrapping = wrapping;
        }
        public void Unwrap()
        {
            // code common to all gifts for unwrapping
            // ...
        }
    }
    public interface IWrappingStyle
    {
    }
