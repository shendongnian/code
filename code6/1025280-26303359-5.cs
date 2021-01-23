     public class Repository
    {
        private List<string> GetData(IQueryable<IContractor> data)
        {
            return (from d in data select d.Name).ToList();
        }
        public List<string> GetFullTime()
        {
            using (var context = new TestDbEntities())
            {
                return GetData(context.FTContractors.AsQueryable());
            }
        }
        public List<string> GetPartTime()
        {
            using (var context = new TestDbEntities())
            {
                return GetData(context.PTContractors.AsQueryable());
            }
        }
    }
