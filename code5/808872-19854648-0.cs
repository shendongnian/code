    public class Bus
    {
        public long BusID { get; set; }
        public long SeatPosition { get; set; }
    }
    var busId = your user input;
    Bus bus = db.Seats.Find(busId);
    if(bus != null)
    {
       bus.SeatPosition = 0;
    }
    db.saveChanges();
