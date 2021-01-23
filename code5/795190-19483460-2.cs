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
    var destination = new Destination {ExpirationDate = DateTime.Now.Date};
    Mapper.CreateMap<Source, Destination>()
          .AfterMap((s,d) => d.ExpirationDate = 
                            d.ExpirationDate.AddDays(s.ExtendedDurationInWeeks * 7));
    destination = Mapper.Map(source, destination);
