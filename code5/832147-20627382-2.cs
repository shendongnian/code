    public class OnBusStart : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        void IWantToRunWhenBusStartsAndStops.Start()
        {
            Bus.Publish(new Event1());
            Bus.Publish(new Event2());
        }
        void IWantToRunWhenBusStartsAndStops.Stop()
        {
        }
    }
