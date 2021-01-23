    public static class Program
    {
        public static void Main(string[] args)
        {
            var broadcaster = new EventBroadcaster();
            var listners = new List<EventListner>();
            for (int i = 1; i < 10; i++)
            {
                var listner = new EventListner(i.ToString(CultureInfo.InvariantCulture));
                listner.ListenTo(broadcaster);
                listners.Add(listner);
            }
            broadcaster.DoLongRunningOperationAndRaiseFinishedEvent();
            Console.WriteLine("Waiting for operation to complete");
            Console.ReadLine();
        }
    }
