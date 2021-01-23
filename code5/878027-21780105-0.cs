    namespace WebApplication1
    {
    public partial class _Default : Page
    {
        public IQueryable<Tourist> SelectArrival()
        {
            return new EnumerableQuery<Tourist>(new List<Tourist>
            {
                new Tourist{ Kod = "1", Name = "Joe", Age = "35"},
                new Tourist{ Kod = "2", Name = "Cliff", Age = "45"},
                new Tourist{ Kod = "3", Name = "Dan", Age = "32"},
            });
        }
    }
    public class Tourist
    {
        public string Kod { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
    }
