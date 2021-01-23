    public class QueryController : BaseReadController
    {
        // notice we don't return an ActionResult? The invoker takes care of this for us
        // we just need to pass the query back to the invoker
        public DetailsQuery About(DetailsQuery query)
        {
            return query;
        }
    }
