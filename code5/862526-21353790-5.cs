    public class Repository: IRepository
    {
       public Job SaveJob(Job job)
       {
           // assuming Entity Framework
           var id = job.Id;
           if (context.Jobs.Any(e => e.Id == id))
           {
               context.Jobs.Attach(job);
               context.ObjectStateManager.ChangeObjectState(jobs, EntityState.Modified);
           }
           else
           {
               context.Jobs.AddObject(myEntity);
           }
           context.SaveChanges();
           return job;
       }
    }
