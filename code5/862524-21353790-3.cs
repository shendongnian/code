    public class Repository: IRepository
    {
       public Job SaveJob(Job job)
       {
           // assuming Entity Framework
           context.SaveChanges();
           return job;
       }
    }
