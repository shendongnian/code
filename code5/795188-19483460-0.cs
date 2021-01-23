    public class Source
    {
        public int ExtendedDurationInWeeks { get; set; }
    }    
    
    public class Destination
    {
        public DateTime ExpirationDate { get; set; }
        public Destination()
        {
            ExpirationDate = DateTime.Now.Date;
        }
    }
    var source = new Source{ ExtendedDurationInWeeks = 2 };
    Mapper.CreateMap<Source, Destination>()
        .AfterMap((src, dest) => dest.ExpirationDate = dest.ExpirationDate.AddDays(src.ExtendedDurationInWeeks * 7));
    var destination = Mapper.Map<Destination>(source);
