    public interface IHasBarBackingField
    {
        Bar RetrieveBar();
    }
    public class HasBarBackingField : IHasBarBackingField
    {
        public HasBarBackingField()
        {
            // the constructor must contain ways to resolve the bar. Since
            // the class is built while proxying you should have all the data
            // available at this moment
        }
        public Bar RetrieveBar()
        {
            return new Bar(); // example, you could have a backing field somewhere in this class
        }
    }
