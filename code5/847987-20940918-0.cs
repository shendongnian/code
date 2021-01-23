    [ImplementPropertyChanged]
    public class Second
    {
        private First first;
        public int B { get {return first.A + 1; } }
        public Second(First first)
        {
            this.first = first;
            this.first.OnPropertyChanged += (s,e) =>
            {
                if (e.PropertyName == "A") this.OnPropertyChanged("B");
            }
    }
