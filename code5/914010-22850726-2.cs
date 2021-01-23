    internal class FooDerived : Foo
    { }
    internal class Foo : INotifyPropertyChanged
    {
        private string someProperty;
        public string SomeProperty
        {
            get { return someProperty; }
            set
            {
                someProperty = value;
                OnPropertyChanged("SomeProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new FooDerived();
            instance.PropertyChanged += (sender, e) => Console.WriteLine("Property '{0}' has been changed!", e.PropertyName);
            FireEventOn(instance: instance,
                        eventName: "PropertyChanged",
                        createEventArgs: () => new PropertyChangedEventArgs(propertyName: "SomeProperty"));
        }
        // only not null reference to instance is needed
        // so will work on any not null instance
        // of any type
        private static void FireEventOn(object instance, string eventName, Func<object> createEventArgs)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo e = GetEvent(eventName, instance.GetType(), lookupWholHierarchy: true);
            var eventDelegate = (MulticastDelegate)e.GetValue(instance);
            if(eventDelegate == null)
            {
                 // nothing to call
                 return;
            }
            foreach (Delegate d in eventDelegate.GetInvocationList())
            {
                Console.Write("Dynamically firing the event: ");
                d.Method.Invoke(d.Target, new[] { instance, createEventArgs() });
            }
        }
        private static FieldInfo GetEvent(string eventName, Type type, bool lookupWholHierarchy = false)
        {
            if (!lookupWholHierarchy)
            {
                return type.GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
            }
            else
            {
                foreach (var t in GetHierarchy(type))
                {
                    var e = t.GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (e != null)
                    {
                        return e;
                    }
                }
            }
            return null;
        }
        private static IEnumerable<Type> GetHierarchy(Type startFrom)
        {
            var current = startFrom;
            while (current != null)
            {
                yield return current;
                current = current.BaseType;
            }
        }
 
       }
    }
