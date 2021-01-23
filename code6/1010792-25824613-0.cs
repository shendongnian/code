    public abstract class Base
    {
        protected Base()
        {
            if (this.GetType().IsPublic)
                throw new InvalidOperationException("Type is not meant to be exposed public");
        }
    }
    public class Der : Base
    {
        public Der()
        {
        }
    }
