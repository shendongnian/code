    public class MyContext:DbContext
    {
         public MyContext:base("ConnectionStringName")
         {
         }
         //--dbSet properties
         public DbSet<Idioma> Idiomas{get;set;}
         //other overridden methods
    }
