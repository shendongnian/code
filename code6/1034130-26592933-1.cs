    public class CityAndStateRepository {
    
        readonly GenericRepository<City> _cities;
        readonly GenericRepository<States> _states;
    
        public CityAndStateRepository(GenericRepository<City> cities,
                                      GenericRepository<States> states)
        {
            _cities = cities;
            _states = states;    
        }
        public virtual Tuple<City, State> GetCityState(string city, string state) {
            var city = _cities.DoStuff
            var state = _states.DoStuff
    
            return new Tuple(city, state)
        }
    }
