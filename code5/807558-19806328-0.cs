    class ChangeNameCommand
    {
        int _id;
        string _name;
        IRepository _repository;
        IEventPublisher _publisher;
        
        public ChangeNameCommand(int id, string name, IRepository repository, IEventPublisher publisher)
        {
            _id = id;
            _name = name;
            _repository = repository;
            _publisher = publisher;
        }
        
        public void Execute()
        {
            User user = _repository.Get(_id)
            user.Name = _name;
            _repository.Save(user);
         
            NameChangedEvent e = new NameChangedEvent();
            _publisher.Publish(e);
        }
    }
    class UserNameChanged : IHandler<NameChangedEvent>
    {
        public void Handle(NameChangedEvent e)
        {
            //TODO...
        }
    }
