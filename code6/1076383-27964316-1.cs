    public class CarWebsiteApiController : BaseApiController<CarWebsiteLoginRequest>
    {
        public override HttpResponseMessage Login(CarWebsiteLoginRequest request)
        {
            // Do some car specific login stuff
            return base.Login(request);
        }
    }
