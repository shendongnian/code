    public class Car
    {
        // Note use of `sender` convention
        public delegate void SoldEventHandler(object sender, string str);
        // Events normally do not have the `On` prefix, also the event
        // name is normally the sense-correct verb such as `Sold` or `Selling`.
        public event SoldEventHandler Sold;
        private bool _isSold;
        public bool IsSold
        {
            get { return _isSold; }
            set
            {
                if (value && !_isSold) {
                   // Only sell when false -> true
                   OnSold("whatever string it is supposed to be");
                }
                _isSold = value;
            }
        }
        // "Typically, to raise an event, you add a method that is marked as protected and virtual.
        //  .. Name this method OnEventName; for example, OnDataReceived."
        public virtual void OnSold(string str)
        {
            // Follow the conventions in the link - ask on SO as to why the local
            // variable and check for null are important/necessary.
            var handler = Sold;
            if (handler != null) {
                handler(this, str);
            }
        }
    // ..
        _car.Sold += p1.Car_OnSell;
        _car.IsSold += Console.ReadLine() == "true" ? true : false;
