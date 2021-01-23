        [HttpGet]
        [BreezeQueryable]
        public QueryResult MerchantList(int take, int skip)
        {
            IQueryable<Merchant> main = _repo.Context.Merchants.OrderBy(m => m.MerchantUID);
            IQueryable<Merchant> items = main.Skip(skip).Take(take);
            foreach (var item in items)
            {
                // Total LifetimeVal
                item.LifetimeVal= TotalLifetimeVal(item.MerchantUID);
                // Total Stores
                item.TotalStores = TotalStores(item.MerchantUID);
            }
            // return items;
            return new QueryResult
            {
                InlineCount = main.Count(),
                Results = items.ToList()
            };
        }
