    // This Code Is Used To Change Contents In Api
    public HttpResponseMessage GetAllcarDetails( string formate)
    {
        CarModel ST = new CarModel();
        CarModel ST1 = new CarModel();
        List<CarModel> li = new List<CarModel>();
        ST.CarName = "Maruti Waganor";
        ST.CarPrice = 400000;
        ST.CarModeles = "VXI";
        ST.CarColor = "Brown";
        ST1.CarName = "Maruti Swift";
        ST1.CarPrice = 500000;
        ST1.CarModeles = "VXI";
        ST1.CarColor = "RED";
        li.Add(ST);
        li.Add(ST1);
        // return li;
        this.Request.Headers.Accept.Add(
          new MediaTypeWithQualityHeaderValue("application/xml"));
          //For Json Use "application/json"
        IContentNegotiator negotiator =
            this.Configuration.Services.GetContentNegotiator();
        ContentNegotiationResult result = negotiator.Negotiate(
            typeof(List<CarModel>), this.Request, this.Configuration.Formatters);
        if (result == null) {
            var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            throw new HttpResponseException(response);
        }
        return new HttpResponseMessage() {
            Content = new ObjectContent<List<CarModel>>(
                li,		        // What we are serializing 
                result.Formatter,           // The media formatter
                result.MediaType.MediaType  // The MIME type
            )
        };
    }  
        
