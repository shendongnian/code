    public class MyBookingsViewModel
    {
        public MyBookingsViewModel()
        {
            this.Carts = new Cart();
        }
        public Cart Carts { get; set; }
        public List<Booking> Bookings { get; set; }
    }
