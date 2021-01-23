    public class SomeController : ApiController
    {
      private IUniversalResponse gProcessRequest;
      public SomeController()
      {
        gProcessRequest = new ProcessRequest(new UserRepository(Request.Properties));
      }
	  [PUT("Modify")]
	  [ResponseType(typeof(SomeResponse))]
	  public async Task<SomeResponse> PutSome(JsonRequest _Data)
	  {
		return await gProcessRequest.CreateSomeResponse(_Data);
	  }
    }
