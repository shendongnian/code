    [RoutePrefix("api/v1/Features")]
    public class FeaturesController : ApiController
    {
        [Route("Products/{product}")]
         public IList<Metadata.FeatureListItemModel> Get(long product){}
