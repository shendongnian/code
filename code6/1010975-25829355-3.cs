    public class GamesApiController : ApiController
        {
        [Route("api/GamesApi/GetGameData")]
        public IEnumerable<BoardGame> GetGameData()
            {
            var data = HttpContext.Current.Application["BoardGameDatabase"] as List<BoardGame>;
            return data;
            }
        }
        
