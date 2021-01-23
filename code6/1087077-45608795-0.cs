    public abstract class CommonApiController: ApiController {
    
        protected ForbiddenResult Forbidden() {
         return new ForbiddenResult(this.Request);
        }
    
        protected ForbiddenResult Forbidden(string reason) {
         return new ForbiddenResult(this.Request, reason);
        }
    
        protected NoContentResult NoContent() {
         return new NoContentResult(this.Request);
        }
    
        protected NoContentResult NoContent(string reason) {
         return new NoContentResult(this.Request, reason);
        }
    
        public class ForbiddenResult: IHttpActionResult {
         private readonly HttpRequestMessage _request;
         private readonly string _reason;
    
         public ForbiddenResult(HttpRequestMessage request, string reason) {
          _request = request;
          _reason = reason;
         }
    
         public ForbiddenResult(HttpRequestMessage request) {
          _request = request;
          _reason = "Forbidden";
         }
    
         public Task < HttpResponseMessage > ExecuteAsync(CancellationToken cancellationToken) {
          var response = _request.CreateResponse(HttpStatusCode.Forbidden, _reason);
          return Task.FromResult(response);
         }
        }
    
        public class NoContentResult: IHttpActionResult {
         private readonly HttpRequestMessage _request;
         private readonly string _reason;
    
         public NoContentResult(HttpRequestMessage request, string reason) {
          _request = request;
          _reason = reason;
         }
    
         public NoContentResult(HttpRequestMessage request) {
          _request = request;
          _reason = "No Content";
         }
    
         public Task < HttpResponseMessage > ExecuteAsync(CancellationToken cancellationToken) {
          var response = _request.CreateResponse(HttpStatusCode.NoContent, _reason);
          return Task.FromResult(response);
         }
        }
       }
