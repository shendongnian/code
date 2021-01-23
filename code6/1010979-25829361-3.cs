    namespace RealTimeDemo.Controllers
    {
    public class GamesApiController : ApiController
        {
        [Route("api/GamesApi/GetGameIds")]
        public IEnumerable<int> GetGameIds()
            {
            var data = HttpContext.Current.Application["BoardGameDatabase"] as List<BoardGame>;
            var IDs = data.Select(x => x.Id);
            return IDs;
            }
        [Route("api/GamesApi/GetGame/{id}")]
        public BoardGame GetGame(int id)
            {
            var data = HttpContext.Current.Application["BoardGameDatabase"] as List<BoardGame>;
            return data.Where(x => x.Id == id).SingleOrDefault();
            }
        }
            
