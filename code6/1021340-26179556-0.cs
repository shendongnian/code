		public class ProductRepository : IRepository 
		{    
			private SomeContext	context;
			
			public void InsertOrUpdate(ProductTicketing ticketing) 
			{ 
				context.Entry(ticketing).State = ticketing.ProductId == 0 ? 
											   EntityState.Added : 
											   EntityState.Modified; 
				context.SaveChanges(); 
			} 
		}
		
		// And a generic version
		public void InsertOrUpdate<T>(T entity) where T : class
		{
			if (context.Entry(entity).State == EntityState.Detached)
				context.Set<T>().Add(entity);
			
			context.SaveChanges(); 
		}
