    using AutoMapper.QueryableExtensions;
    
    public class ClassRepository
    {
        public Class GetClass(Expression<Func<Class, bool>> query)
        {
             
            using (var context = new DBEntities())
            {
                return context.InternalClasses.Project().To<Class>().FirstOrDefault(query);
            }    
        }
    }
