        public class BusinessUnit
        {
            public Guid Id { get; set; }
            public String Name { get; set; }
        }
        public void GetAllBusinessUnits(Action<QueryExpression> queryModifier = null)
        {
            foreach (BusinessUnit m in RetrieveAllBusinessUnit(this.Service, 1000, queryModifier))
            {
                
                //Console.WriteLine(m.Name);
            }
        }
        public static IEnumerable<BusinessUnit> RetrieveAllBusinessUnit(IOrganizationService service, int count = 1000, Action<QueryExpression> queryModifier = null)
        {
            QueryExpression query = new QueryExpression("businessunit")
            {
                ColumnSet = new ColumnSet("businessunitid", "name"),
                PageInfo = new PagingInfo()
                {
                    Count = count,
                    PageNumber = 1,
                    PagingCookie = null,
                }
            };
            if (queryModifier != null)
            {
                queryModifier(query);
            }
            while (true)
            {
                EntityCollection results = service.RetrieveMultiple(query);
                foreach (Entity e in results.Entities)
                {
                    yield return new BusinessUnit()
                    {
                        Id = e.GetAttributeValue<Guid>("businessunitid"),
                        Name = e.GetAttributeValue<String>("name")
                    };
                }
                if (results.MoreRecords)
                {
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = results.PagingCookie;
                }
                else
                {
                    yield break;
                }
            }
        }
