    public class SeatType : DescriptiveEnum<SeatType, int>
    {
        public static readonly SeatType Window = new SeatType("Window Seat", 1);
        public static readonly SeatType Aisle = new SeatType("Aisle Seat", 2);
        public static readonly SeatType AnythingExceptSeatNearBathroom = new SeatType("Anything Except Seat Near Bathroom", 3);
        private SeatType(string desc, int code)
            : base(desc, code)
        {
        }
    }
