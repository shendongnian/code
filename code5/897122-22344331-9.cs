    // Abstractions
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent {
        void Handle(TEvent e);
    }
    public interface IEventPublisher {
        void Publish<TEvent>(TEvent e) where TEvent : IDomainEvent;
    }
    // Events
    public class JobStatusChanged : IDomainEvent {
        public readonly int JobId;
        public JobStatusChanged(int jobId) {
            this.JobId = jobId;
        }
    }
    // Container-specific Event Publisher implementation
    public class SimpleInjectorEventPublisher : IEventPublisher {
        private readonly Container container;
        public SimpleInjectorEventPublisher(Container container) {
            this.container = container;
        }
        public void Publish<TEvent>(TEvent e) {
            var handlers = container.GetAllInstances<IEventHandler<TEvent>>();
            foreach (var handler in handlers) {
                hanlder.Handle(e);
            }
        }
    }
