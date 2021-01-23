    public class Repository<T> : IDisposable
        {
            public  static DataContext context { get; set; } 
            public static void Insert(T item)
            {
                var table = context.GetTable<T>(); 
                table.InsertOnSubmit(item);
                context.SubmitChanges();      
            } 
            
            public void Dispose()
            {
                context.Dispose();
            }
        } 
