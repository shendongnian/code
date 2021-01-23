    //we need to setup some context stuff that you'll notice is passed 
    //in to the builder WithControllerContext...and then the controller is 
    //used to get the ActionFilter primed
    //0. Setup WebApi Context
    var config = new HttpConfiguration();
    var route = config.Routes.MapHttpRoute("DefaultSlot", "cars/_services/addPickup");
    var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "AddPickup" } });
    var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:24244/cars/_services/addPickup");
    request.RequestUri = new Uri("http://localhost:24244/cars/_services/addPickup");
    List<string> x = new List<string>() { MediaType.CarsV2.GetDescription() };
    request.Headers.Add("Accept", x);
     ....obviously 1 & 2 I skipped as they aren't relevant
    //3. controller
    PickupController controller = new PickupControllerBuilder()
    //.MoqReqHlpr_IsAny_CreateResp(HttpStatusCode.OK) //3a. setup return message
    .MoqCarRepoAny_ReturnsSampleDataCar(new Guid("000...0011")) //3b. car object
    .MoqFulfillRepoAnyCar_IsAny_IsQuickShop(true) //3c. fulfillment repository
    .MoqCartRepoAnyCar_IsAny_UpdateCar(true) //3d. car repository
    .WithControllerContext(config, routeData, request)
    .WithHttpPropertyKey(lsd);
    //HttpActionContextFilter is the name of my ActionFilter so as you can
    //see we actually instantiate the ActionFilter then hook it to the
    //controller instance
    var filter = new HttpActionContextFilter();
    filter.OnActionExecuting(controller.ActionContext);
