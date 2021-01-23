    lock (job)
    {
         using (MyEntities context = new MyEntities())
         {
               context.Jobs.Attach(job);
               job.State = value;
               context.SaveChanges();
               context.Detach(job);  // Detach the object
          }
    }
