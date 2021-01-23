    public HttpResponseMessage GetAll() {
    List<MyEntity> before = MyEntityRepository.GetAll();
    return Request.CreateResponse(HttpStatusCode.OK,
		before.Select(x => new ExtendedEntity 
		{
		   Property1    = x.Property1,
		   Property2    = x.Property2,
		   ExtendedProp = ExtendedPropProvider.getExtended(x)
		}));
