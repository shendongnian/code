    public class Sample
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid SampleId { get; set; }
    
        public Piece SaloonPiece { get; set; }
        public FloorType SaloonFloor { get; set; }
        public WallType SaloonWall { get; set; }
        public DoorType SaloonDoor { get; set; }
        public WindowType SaloonWindow { get; set; }
        public Piece RoomPiece { get; set; }
        public FloorType RoomFloor { get; set; }
        public WallType RoomWall { get; set; }
        public DoorType RoomDoor { get; set; }
        public WindowType RoomWindow { get; set; }
        public Piece BalconyPiece { get; set; }
        public FloorType BalconyFloor { get; set; }
        public WallType BalconyWall { get; set; }
        public DoorType BalconyDoor { get; set; }
        public WindowType BalconyWindow { get; set; }
    }
