    public partial class Product : INotifyPropertyChanged
    {
        public Product()
        {
            this.Designs = new ObservableCollection<Design>();
            this.Designs.CollectionChanged += ContentCollectionChanged;
        }
        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // This will get called when the collection is changed
            // HERE YOU CAN ALSO FIRE THE PROPERTY CHANGED 
        }
        public int BookingProductId { get; set; }
        public System.Guid BookingId { get; set; }
        public decimal Price { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual ObservableCollection<Design> Designs { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
