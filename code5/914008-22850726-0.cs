    using System;
    using System.ComponentModel;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
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
                var instance = new Foo();
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
                var eventDelegate = (MulticastDelegate)instance.GetType().GetField(eventName, flags)
                    .GetValue(instance);
    
                foreach (Delegate d in eventDelegate.GetInvocationList())
                {
                    Console.Write("Dynamically firing the event: ");
                    d.Method.Invoke(d.Target, new[] { instance, createEventArgs() });
                }
            }
        }
    }
