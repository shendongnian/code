     System.Data.Entity.Core.Objects.ObjectContext oc = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)dataContext).ObjectContext;
     foreach(var Cases in user.TBL_USER_CASE.ToList())
        {                        
           oc.DeleteObject(Cases);                       
        }                    
        oc.SaveChanges();
        dataContext.TBL_USER.Remove(user);
