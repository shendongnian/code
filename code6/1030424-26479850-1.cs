        public IList<Countries> getCountries()
        {
            IList<Ter.Models.Countries> countries;
            IQuery query;
            using (ISession session = OpenSession())
            {
                try
                {
                     query = session
        .CreateQuery("select distinct citizenship AS citizenship from Ters")
        .SetResultTransformer(Transformers.AliasToBean<Countries>());
                }
                catch (Exception c) 
                {
                    query = null;
                }
                 countries = query.List<Countries>();
            }
            return countries;
        }
