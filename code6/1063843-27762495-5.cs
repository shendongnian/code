    public class EventListner
    {
        private readonly string _id;
        public EventListner(string id)
        {
            _id = id;
        }
        public void ListenTo(EventBroadcaster broadcaster)
        {
            broadcaster.SomeEventOccured += OnSomeEventOccured;
        }
        private async void OnSomeEventOccured(object sender, EventArgs eventArgs)
        {
            var currentTime = DateTime.Now;
            Console.WriteLine("EventListner {0} received at {1}", _id,
                currentTime.ToString("dd-MM-yyyy HH:mm:ss.fffffff"));
            
            //Not required just to show this does not affect other instances.
            //await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
