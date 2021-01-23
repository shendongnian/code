    namespace MvcApplicationrazor.Models
    {
        public class CountryModel
        {
            public List<State> StateModel { get; set; }
            public SelectList FilteredCity { get; set; }
        }
        public class State
        {
            public int Id { get; set; }
            public string StateName { get; set; }
        }
        public class City
        {
            public int Id { get; set; }
            public int StateId { get; set; }
            public string CityName { get; set; }
        }
    }  
