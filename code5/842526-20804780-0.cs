    public class DeferredEventDispatcher : IEventDispatcher
    {
        private readonly IEventDispatcher inner;
        private readonly ConcurrentQueue<Action> events = new ConcurrentQueue<Action>();
        public DeferredEventDispatcher(IEventDispatcher inner)
        {
            this.inner = inner;
        }
        public void Dispatch<TEvent>(TEvent e)
        {
            events.Enqueue(() => inner.Dispatch(e));
        }
        public void Resolve()
        {
            Action dispatch;
            while (events.TryDequeue(out dispatch))
            {
                dispatch();
            }
        }
    }
    public class UnitOfWork
    {
        public void Commit()
        {
            session.SaveChanges();
            dispatcher.Resolve(); // raise events
        }
    }
