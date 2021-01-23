    public class Room
    {
        [Key]
        public int RoomId { get; set; }
    
        public string RoomName { get; set; }
    
        public GenderEnum Gender { get; set; }
    
        public RoomStatusEnum RoomStatus { get; set; }
    
        public virtual ICollection<Bunk> Bunks { get; set; }
        // convenience
        public virtual ICollection<Booking> Bookings { get; set; }
    }
    
    public class Bunk
    {
        [Key]
        public int BunkId { get; set; }
    
        public BunkStatusEnum BunkStatus { get; set; }
    
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        // convenience
        public virtual ICollection<Booking> Bookings { get; set; }
    }
    
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
    
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    
        [ForeignKey("Bunk")]
        public int BunkId { get; set; }
        public Bunk Bunk { get; set; }
    
        public int Duration { get; set; }
    
        [ForeignKey("Preferred_Room")]
        public int RoomId { get; set; }
        public Room Preferred_Room { get; set; }
    
        public Decimal Price { get; set; }
    
        public BookStatusEnum BookingStatus { get; set; }
    }
