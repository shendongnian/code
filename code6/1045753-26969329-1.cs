    public class MyService : IMyServiceBase
    {
        private MyServiceDataDataContext dataContext;
        public MyService(MyServiceDataDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Domain.Data.MyObject GetSomething(int id)
        {
            return (
                from s in this.dataContext.MyObjects                
                select Mapper.Map<MyObject, Domain.Data.MyObject>(s))
                .SingleOrDefault();
        }
    }
