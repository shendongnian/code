	public class MyRepository : IMyRepository
	{
		private readonly IMyDbContext _myDbContext;
		public MyRepository (IMyDbContext myDbContext)
		{
			_myDbContext = myDbContext;
		}
		public async Task<SomeEntity> UpdateSomeEntity(SomeEntity updatedSomeEntity)
		{
			_myDbContext.UpdateGraph(updatedSomeEntity, map => map.OwnedCollection(p => p.SomeChildCollection));
			await _myDbContext.SaveChangesAsync();
			
			return updatedSomeEntity;
		}
    }
