    public class Request { }
    public class Response {
      public Response(string text) {}
    }
    public interface IController<out T> where T: Request {
        Response HandleRequest(T request);
    }
    public class BlergRequest : Request { }
    public class BlergController : IController<BlergRequest> {
        public Response HandleRequest(BlergRequest request) {
            return new Response("Here's your blergs!");
        }
        public void Test() {
          IController<Request> controller = new BlergController();
        }
    }
