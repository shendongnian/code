    public class EventWiringFacilityTests
    {
        public void RegisterInterceptorWithListenerAndMakeSureListenerSubscribes()
        {
            var container = new WindsorContainer();
            container.AddFacility<EventWiringFacility>();
            container.Register(Component.For<SomeInterceptor>());
            container.Register(
               Component.For<SimplePublisher>()
                  .PublishEvent(p => p.Event += null,
                                x => x.To<SimpleListener>("foo", l => l.OnEvent(null, null))),
               Component.For<SimpleListener>().Interceptors<SomeInterceptor>().Named("foo"));
            var someInterceptor = container.Resolve<SomeInterceptor>();
            var simpleListener = container.Resolve<SimpleListener>();
            Assert.That(simpleListener.EventHasHappened, Is.False);
            var simplePublisher = container.Resolve<SimplePublisher>();
            simplePublisher.Trigger();
            Assert.That(simpleListener.EventHasHappened);
            simpleListener.Snap();
            Assert.That(someInterceptor.Intercepted);
        }
    }
    public class SomeInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Intercepted = true;
            invocation.Proceed();
        }
        public bool Intercepted { get; set; }
    }
    public class SimplePublisher
    {
        public event EventHandler Event;
        public void Trigger()
        {
            if (Event != null)
            {
                Event(this, new EventArgs());
            }
        }
    }
    public class SimpleListener
    {
        public bool EventHasHappened { get; set; }
        public void OnEvent(object sender, EventArgs e)
        {
            EventHasHappened = true;
        }
        public virtual void Snap()
        {
            
        }
    }
