    public interface IBouncer {
        IEnumerable<IFooConsumer> WhoIsInside {get;}
        void WelcomeTo(IFooConsumer consumer);
        void EscortOut(IFooConsumer consumer);
    }
    public class Bouncer {
        private IList<IFooConsumer> _inside {get;}
        void WelcomeTo(IFooConsumer consumer) {
            _inside.Add(consumer);
	}
        void EscortOut(IFooConsumer consumer);
            _inside.Remove(consumer);
        }
        IEnumerable<IFooConsumer> WhoIsInside {
            get {
                return _inside;
            }
        }
    public Consumer: IFooConsumer {
        FooHappened() {
            // Do something.
	}
        // no need to implement constructor/dispose
    }
    class Bar
    {
        public Bar(IBouncer bouncer) { ... }
        public void Foo()
        {
            // foo-ing ==> alernatively create a function on Bouncer that does this. And keep WhoIsInside private.
            foreach (var f in bouncer.WhoIsInside) f.FooHappened();
        }
    }
    class BouncerRegistrationFacility : AbstractFacility
    {
        private IBouncer _bouncer
        protected override void Init()
        {
            Kernel.ComponentCreated += ComponentCreated;
            Kernel.ComponentDestroyed += ComponentDestroyed;
        }
        void ComponentCreated(Castle.Core.ComponentModel model, object instance)
        {
            if (!(instance is IFooConsumer)) return;
            if (_bouncer == null) _bouncer = Kernel.Resolve<IEventAggregator>();
            _bouncer.WelcomeTo(instance);
        }
        void ComponentDestroyed(Castle.Core.ComponentModel model, object instance)
        {
            if (!(instance is IFooConsumer)) return;
            if (_bouncer == null) return;
            _bouncer.EscortOut(instance);
        }
    }
