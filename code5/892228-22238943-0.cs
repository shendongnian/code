    config.Routes.MapHttpRoute(
        name: "Movies",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
    );
    
    public class MovieController : ApiController
    {
        // GET api/<controller>?genre=<genre>&year=<year>
        public IEnumerable<Movie> Get(string genre = null, int? year = null)
        {
            return MoviesDB.All(string genre, int year);
        }
    
        // GET api/<controller>/5?genre=<genre>&year=<year>
        public Movie Get(int id, string genre = null, int? year = null)
        {
            return MoviesDB.ThisSpecificOne(string genre, int year, id);
        }
    
        // POST api/<controller>?genre=<genre>&year=<year>
        public void Post([FromBody]Movie value, string genre = null, int? year = null)
        {
        }
    
        // PUT api/<controller>/5?genre=<genre>&year=<year>
        public void Put(int id, [FromBody]Movie value, string genre = null, int? year = null)
        {
        }
    
        // DELETE api/<controller>/5?genre=<genre>&year=<year>
        public void Delete(int id, string genre = null, int? year = null)
        {
        }
    }
