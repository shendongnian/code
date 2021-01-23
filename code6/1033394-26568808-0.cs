    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var DataContext = new StackOverflowContext();
    
                DateTime? date = null;
                var entity = new Model()
                {
                    GoDate = date
                };
    
                DataContext.Models.Add(entity);
                DataContext.SaveChanges();
            }
        }
    
        class Model
        {
            public int ModelId { get; set; }
    
            public DateTime? GoDate { get; set; }
        }
    
        class StackOverflowContext : DbContext
        {
            public DbSet<Model> Models { get; set; }
        }
    }
