    public class ExampleReceiver
    {
        public PropertyChangeSubscriber<string> Id { get; set; }
        public PropertyChangeSubscriber<bool> TestBool { get; set; }
        public MyExampleClass(PropertyChangePublisherBase publisher)
        {
            Id = new PropertyChangeSubscriber<string>("Id", publisher);
            TestBool = new PropertyChangeSubscriber<bool>("TestBool", publisher);
        }
    }
