    public class ActionFactory : IActionFactory
    {
        private readonly Container _container;
        private readonly Dictionary<string, InstanceProducer> _producers; 
        public ActionFactory(Container container)
        {
            _container = container;
            _producers = new Dictionary<string, InstanceProducer>(StringComparer.OrdinalIgnoreCase);
        }
        public IAction Create(ActionType type)
        {
            var action = _producers[type.ToString()].GetInstance();
            return (IAction) action;
        }
        public void Register(Type type, string name, Lifestyle lifestyle = null)
        {
            lifestyle = lifestyle ?? Lifestyle.Transient;
            var registration = lifestyle.CreateRegistration(typeof (IAction), type, _container);
            var producer = new InstanceProducer(typeof (IAction), registration);
            _producers.Add(name, producer);
        }
    }
