        public List<Product> ProductQuery(List<Product> Products
            , int? IDCriteria
            , string TitleCriteria
            , string StatusCriteria)
        {
            var query = Products.AsQueryable();
            if (IDCriteria != null)
            {
                query.Where(x => x.ID == IDCriteria);
            }
            if (!String.IsNullOrEmpty(TitleCriteria))
            {
                query.Where(x => x.Title == TitleCriteria);
            }
            if (!String.IsNullOrEmpty(StatusCriteria))
            {
                if (StatusCriteria.Equals("all", StringComparison.CurrentCultureIgnoreCase))
                {
                    query.Where(x => x.Status.Length > 0 || String.IsNullOrEmpty(x.Status)); //will return any status
                }
                else
                {
                    query.Where(x => x.Status == StatusCriteria);
                }
            }
            return query.ToList();
        }
