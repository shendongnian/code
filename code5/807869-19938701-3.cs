        public List<Account> Query(Expression<Func<Account, bool>> expression)
        {
            using (Data.CustomerData data = new Data.CustomerData(_connstring))
            {
                 return MapList(data.Query<Data.Database.ACCOUNT>(expression.Convert<Account, Data.Database.ACCOUNT>()).ToList());
            }
