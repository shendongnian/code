    public interface IRequest { }
    public class Request : IRequest { }
    public class Response {
      public Response(string text) {}
    }
    public interface IController<T> where T: IRequest {
        Response HandleRequest(T request);
    }
    public class BlergRequest : IRequest { }
    public class BlergController : IController<IRequest> {
        public Response HandleRequest(BlergRequest request) {
            return new Response("Here's your blergs!");
        }
        public void Test() {
          IController<IRequest> controller = new BlergController();
        }
    }
