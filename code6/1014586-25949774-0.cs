    class SampleCollection
    {
        private Point[] arr = new Point[100];
        public Point this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }
