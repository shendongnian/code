    [DataContract]
    public class RommDto{
        [DataMember]
        public int Id {get; set;}
        [DataMember]
        public RoomType Type {get; set;}
    }
.....
    [LogBeforeAfter]
    RoomDto[] GetAllRoomTypes()
    {
    ....
    }
