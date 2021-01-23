    [WebMethod]
    public void AddTable(string first, string last, string email, long telephone, int people, string special, string bookingDate)
    {
    Date time dt = DateTime.parse(bookingDate);
    using (BookingLinqDataContext bl = new BookingLinqDataContext())
    {
        bl.AddTable(first, last, email, telephone, people, dt, special);
    }
