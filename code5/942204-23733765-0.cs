    public interface IContainer
    {
        string getFeatures();
    }
    public class Container : IContainer
    {
        public string getFeatures()
        {
            return "Container";
        }
    }
    public abstract class ContainerDecorator : IContainer
    {
        protected IContainer container;
        protected ContainerDecorator(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
        public abstract string getFeatures();
    }
    public class StringFormatDecorator : ContainerDecorator
    {
        private readonly string _format;
        public StringFormatDecorator(IContainer container, string format) : base(container)
        {
            _format = format;
        }
        public override string getFeatures()
        {
            string features = container.getFeatures();
            features = features != string.Empty ? string.Format(_format, features) : features;
            return features;
        }
    }
    // a decorator to add wheels
    public class MovableConatiner : StringFormatDecorator
    {
        public MovableConatiner(IContainer container) : base(container, "{0} , four wheels")
        {
        }
    }
    // a decorator to add lid to contaner
    public class LidConatiner : StringFormatDecorator
    {
        public LidConatiner(IContainer container) : base(container, "{0} , Lid")
        {
        }
    }
    
