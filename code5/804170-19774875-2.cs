    [RoutePrefix( "api/v2/test" )]
    public class EntityController : ApiController {
        [Route( "" )]
        public IEnumerable<Entity> GetAll() {
            // ...
        }
        [Route( "{id:int}" )]
        public Entity Get( int id ) {
            // ...
        }
        
        // ... stuff
        [HttpGet]
        [Route( "{id:int}/children" )]
        public IEnumerable[Child] Children( int id ) {
            // ...
        }
    }
    
    ///
    /// elsewhere
    ///
    // outputs: api/v2/test/5
    request.HttpRouteUrl( HttpMethod.Get, new {
        controller = "entity",
        id = 5
    } )
    // outputs: api/v2/test/5/children
    request.HttpRouteUrl( HttpMethod.Get, new {
        controller = "entity",
        action = "children",
        id = 5
    } )
