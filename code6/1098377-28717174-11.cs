     public interface IHaveAnId
     {
          int id { get;set; }
     }
 
    public class Blah : IHaveAnId
    {
        public int id { get; set; }
        public string blahh { get; set; }
    }
    public class Doh : IHaveAnId
    {
        public int id {get;set;}
        public string dohh { get; set; }
        public string mahh { get; set; }
    }
