    public class EntityDBContext: DbContext, IObjectContextAdapter
    {
        ObjectContext IObjectContextAdapter.ObjectContext {
            get { 
               return (this as IObjectContextAdapter).ObjectContext;
            }
        }
    }
