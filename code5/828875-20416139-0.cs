    public partial class GetAvailableRooms_Result
    {
        public string Name { get; set; }
        public Nullable<int> Available { get; set; }
        public Nullable<int> Reservations { get; set; }
        public String Date { get; set; } // <-- change is here.
        public Nullable<bool> Gender { get; set; }
    }
