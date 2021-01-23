    public abstract class Gift
    {
        protected WrappingStyle wrapping;
        public void unwrap();
        ...
    }
    public abstract class WrappingStyle
    {
        protected String name;
        
        ...
    }   
