    public class CustomProperties
    {
        public string PropertyA { get; private set; }
        public string PropertyB { get; private set; }
    }
    public interface ICustomProperties
    {
          string PropertyA { get; }
          string PropertyB { get; }
    }
    public abstract class ClassA : ICustomProperties
    {
        private readonly CustomProperties properties;
        public ClassA(CustomProperties properties)
        {
            this.properties = properties;
        }
        public string PropertyA
        {
            get { return properties.PropertyA; }
        }
        public string PropertyB
        {
            get { return properties.PropertyB; }
        }
        public string PropertyX { get; set; }
        public void MethodA()
        {
            // do something
        }
    }
