    public class Statistics
    {
        public event EventHandler ReservationCountChanged;
        private int _reservationCount;
        // think about how you may restrict set access for this model
        public int ReservationCount 
        { 
            get { return _reservationCount; } 
            protected set
            {
                if (_reservationCount != value)
                {
                    _reservationCount = value;
                    if (ReservationCountChanged != null)
                        ReservationCountChanged(this, new EventArgs());
                }
            }
        }
        public Statistics() { }
    }
