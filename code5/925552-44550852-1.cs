         ActivityEntity activity = new ActivityEntity();
          activity.name="vv";
        activity.ID = 22 ; //sample id
       var savedActivity = context.Activities.Find(22);
                
                if (savedActivity!=null)
                {
                    context.Entry(savedActivity).State = EntityState.Detached;
                    context.SaveChanges();
                    activity.CreatedUserId = savedActivity.CreatedUserId;
                    activity.Created = savedActivity.Created;                
                    context.Entry(activity).State = EntityState.Modified;
                    context.SaveChanges();
                    return activity.ID;
                }
