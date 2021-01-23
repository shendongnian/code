       var savedActivity = context.Activities.Find(inputActivity.activityId);
                context.Entry(savedActivity).State = EntityState.Detached;
                context.SaveChanges();
                if (savedActivity!=null)
                {
                    activity.ID = inputActivity.activityId;
                    activity.CreatedUserId = savedActivity.CreatedUserId;
                    activity.Created = savedActivity.Created;
                    context.Entry(activity).State = EntityState.Modified;
                    context.SaveChanges();
                    return activity.ID;
                }
