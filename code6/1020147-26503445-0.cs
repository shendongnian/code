    public class FrequentlyAccessedQueries : Controller
    {
        private CATALOGEntities db = FrequentlyAccessedQueries.entities();
        public static CATALOGEntities entities()
        {
            QueryDetails qdetails = new QueryDetails();
            bool uk = qdetails.IsCountryUK;
            if (uk) 
            {
                return new CATALOGEntities("name=CATALOGEntitiesUK");
            }
            else 
            {
                return new CATALOGEntities("name=CATALOGEntitiesUSA");
            }
        }
    }
