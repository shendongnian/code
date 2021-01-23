    public class EntityFrameworkConfiguration : DbConfiguration
        {
            public EntityFrameworkConfiguration()
            {
                AddInterceptor(new DefaultOrderInterceptor());
            }
        }
