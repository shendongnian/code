    public class EFObject
    {
        public DateTime D { get; set; }
    }
    public class DTOObject
    {
        public string DS { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mapper.CreateMap<EFObject, DTOObject>().
                ForMember(dtoo => dtoo.DS, opt => opt.MapFrom(efo => efo.D.ToString("g")));
            var fromDB = new EFObject() { D = DateTime.Now };
            var toDTO = Mapper.Map<EFObject, DTOObject>(fromDB);
        }
    }
