    using System.EntityFramework.Extensions.ObjectQueryExtensions; //Include this package
    {
      ....
       public void Update(int gid , int aid , int tid)
       {
         context.ActivityTasks.Update(t => new ActivityTask() { GroupID = gid }, 
                                      t => t.activityID == aid && t.taskID == tid);     
       }
      ....
    }
