    public class BunkViewModel:Bunk
    {       
        public BunkViewModel()
        {
            Mapper.CreateMap<Bunk,BunkViewModel>();
        }
        //I'm assuming that you already have some id in bunk to point to room it belongs. 
        //But writing it here to make it clear
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    
        //Use AutoMapper to Map
        public static BunkViewModel Map(Bunk source)
        {
            return Mapper.Map<Bunk,BunkViewModel>(source);    
        }
    }
