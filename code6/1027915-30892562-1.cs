    [RoutePrefix("api/v1/Features")]
    public class FeaturesV1Controller : ApiController
    {
        [Route("Products/{product}")]
         public IList<Metadata.FeatureListItemModel> Get(long product){}
