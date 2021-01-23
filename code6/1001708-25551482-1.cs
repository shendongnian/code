    public abstract class ResponseBaseType
    {
        public abstract IEnumerable<ElementResponseType> Leaves { get; }
    }
    public class GroupResponseType : ResponseBaseType
    {
        public IEnumerable<ResponseBaseType> Children { get; private set; }
        public override IEnumerable<ElementResponseType> Leaves
        {
            get
            {
                return Children.SelectMany(child => child.Leaves);
            }
        }
    }
    public class ElementResponseType : ResponseBaseType
    {
        public override IEnumerable<ElementResponseType> Leaves
        {
            get
            {
                yield return this;
            }
        }
    }
