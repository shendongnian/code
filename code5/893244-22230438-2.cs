    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            private readonly List<MyEvent> _myEvents;
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                // Add some dummy events occuring on specific time
                _myEvents = new List<MyEvent>()
                    {
                        new MyEvent("My event A", DateTime.Now.AddSeconds(5)),
                        new MyEvent("My event B", DateTime.Now.AddSeconds(10)),
                        new MyEvent("My event C", DateTime.Now.AddSeconds(20))
                    };
    
                // Fire up the event iterator
                Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            // Report events' status
                            DateTime now = DateTime.Now;
    
                            foreach (var myEvent in _myEvents.Where(e => e.Time <= now))
                                System.Diagnostics.Debug.WriteLine(string.Format("Event '{0}' already held", myEvent.Name));
    
                            foreach (var myEvent in _myEvents.Where(e => e.Time > now))
                            {
                                string notification = "Event '{0}' at '{1}' starting in {2} seconds";
                                TimeSpan timeSpan = myEvent.Time - now;
                                notification = string.Format(notification, myEvent.Name, myEvent.Time, (int)timeSpan.TotalSeconds);
                                System.Diagnostics.Debug.WriteLine(notification);
                            }
                            System.Diagnostics.Debug.WriteLine(new string('-', 15));
    
                            // Wait for a while before next iteration
                            Thread.Sleep(3000);
                        }
                    });
            }
        }
    
        // Dummy
        public class MyEvent
        {
            public MyEvent()
            {}
    
            public MyEvent(string name, DateTime time)
            {
                Name = name;
                Time = time;
            }
    
            public string Name { get; set; }
    
            public DateTime Time { get; set; }
        }
    }
