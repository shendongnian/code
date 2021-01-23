    public sealed class SingletonOne
    {
        private static readonly Lazy<SingletonOne> instance = new Lazy<SingletonOne>(() => new SingletonOne());
        private Lazy<Controller> controller = new Lazy<Controller>(() => new Controller(properties));
        private static object properties = null;
        public static SingletonOne Instance { get { return instance.Value; } }
        public Controller GetController(object properties)
        {
            SingletonOne.properties = properties;
            return this.controller.Value;
        }
    }
    public sealed class SingletonTwo
    {
        private static readonly SingletonTwo instance = new SingletonTwo();
        private Controller controller;
        private static object properties = null;
        public static SingletonTwo Instance
        { 
            get 
            { 
                return SingletonTwo.instance; 
            } 
        }
        public Controller GetController(object properties)
        {
            SingletonTwo.properties = properties;
            if(this.controller == null)
            {
                this.controller = new Controller(SingletonTwo.properties);
            }
            return this.controller;
        }
    }
    public class Controller 
    {
        public Controller(object properties) { }
    }
