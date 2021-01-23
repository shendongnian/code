     public static TableQuery<TElement> AndWhere<TElement>(this TableQuery<TElement> query, string filter)
                where TElement : ITableEntity,new ()
            {
                if (query.FilterString.IsNullOrEmpty())
                {
                    query.FilterString =  filter;
                }
                else
                {
                    query.FilterString = TableQuery.CombineFilters(query.FilterString, TableOperators.And, filter);
                }
                return query;
            }
