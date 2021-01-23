    public sealed class CustomerIdCache : AbstractCache<CustomerIdCache, Customer>
    {
        private CustomerIdCache()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override TimeSpan GetExpiration()
        {
            return new TimeSpan(0, 1, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected override Customer GetSingleElement(ITimeJackContext db, object[] key)
        {
            Guid id = (Guid)key[0];
            Customer customer = db.Customers.AsNoTracking().SingleOrDefault(x => x.Id == id);
            return customer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override IEnumerable<object> GetKey(Customer entry)
        {
            return new object[] { entry.Id };
        }
