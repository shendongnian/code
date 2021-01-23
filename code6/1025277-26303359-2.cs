    public class Repository
        {
            public List<string> GetData(IQueryable<IContractor> data)
            {
                return (from d in data select d.Name).ToList();
            }
        }
    
        public class Tester
        {
            public List<string> GetFullTime()
            {
                using (var context = new TestDbEntities())
                {
                    var rep = new Repository();
                    return rep.GetData(context.FTContractors.AsQueryable());
                }
            }
            
            public List<string> GetPartTime()
            {
                using (var context = new TestDbEntities())
                {
                    var rep = new Repository();
                    return rep.GetData(context.PTContractors.AsQueryable());
                }
            }
        }
