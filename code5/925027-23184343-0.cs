    public class PromiseListenerBase
    {
    }
    public class PromiseListener<T> : PromiseListenerBase
    {
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
            foreach (var listener in listeners)
            {
                // do something
            }
        }
    }
