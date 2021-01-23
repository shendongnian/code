    interface IEventRaiser
    {
        void Raise<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
    class AutofacEventRaiser : IEventRaiser
    {
        private readonly IComponentContext context;
        public AutofaceEventRaiser(IComponentContext context)
        {
            this.context = context;
        }
        public void Raise<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            using(var scope = context.BeginLifetimeScope("eventRaiser"))
            {
                foreach(var handler in scope.Resolve<IEnumerable<IDomainEventHandler<TEvent>>>())
                {
                    handler.Handle(@event);
                }
            } // scope is disposed - no memory leak
        }
    }
    // then, in the composition root:
    IContainer theContainer = BuildTheAutofacContainer();
    DomainEvents.EventRaiser = new AutofacEventRaiser(theContainer);
