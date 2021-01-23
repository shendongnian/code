    public abstract class PromiseListenerBase
    {
        public abstract Type PromisedType { get; }
        public abstract void HandleResolution(object value);
    }
    public class PromiseListener<T> : PromiseListenerBase
    {
        public override Type PromisedType
        {
            get { return typeof(T); }
        }
        public override void HandleResolution(object value)
        {
            T val = (T)value;
            this.IsResolved(val);
        }
        public virtual void IsResolved(T value) { /* some logic */ }
        public virtual void IsSpoiled() { /* some logic */ }
    }
    public class FloatListener : PromiseListener<float>
    {
        public override void IsResolved(float value)
        {
            Console.Out.WriteLine("FloatListener value {0}", value);
        }
    }
    public class IntListener : PromiseListener<int>
    {
        public override void IsResolved(int value)
        {
            Console.Out.WriteLine("IntListener value {0}", value);
        }
    }
    public class SomethingUsingPromiseListeners
    {
        public void SomeMethod()
        {
            Dictionary<string, PromiseListenerBase> listeners =
                new Dictionary<string, PromiseListenerBase>();
            listeners.Add("float", new FloatListener());
            listeners.Add("int", new IntListener());
            int someValue = 123;
            foreach (PromiseListenerBase listener in listeners.Values)
            {
                if (listener.PromisedType == someValue.GetType())
                {
                    listener.HandleResolution(someValue);
                }
            }
        }
    }
