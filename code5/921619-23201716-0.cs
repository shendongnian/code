	public class GenericInterfaceTests
	{
		[Fact]
		public void IncertsStringEntity()
		{
			// Arrange.
			var entity = "100500";
			var entityType = entity.GetType();
			var genericType = typeof(Repository<>).MakeGenericType(entityType);
			var result = Activator.CreateInstance(genericType);
			// Act.
			(result as IRepository).Insert(entity);
			
			// Assert.
			result.Should().BeOfType<Repository<string>>();
			var repository = result as Repository<string>; 
			
			repository.DataSource.Should().Contain(entity);
		}
		[Fact]
		public void InsertsIntegerEntity()
		{
			// Arrange.
			var entity = 100500;
			var entityType = entity.GetType();
			var genericType = typeof(Repository<>).MakeGenericType(entityType);
			var result = Activator.CreateInstance(genericType);
			// Act.
			(result as IRepository).Insert(entity);
			// Assert.
			result.Should().BeOfType<Repository<int>>();
			var repository = result as Repository<int>; 
			
			repository.DataSource.Should().Contain(entity);
		}
	}
	public interface IRepository<TEntity>
	{
		void Insert(TEntity entity);
	}
	public interface IRepository
	{
		void Insert(object entity);
	}
	public class Repository<TEntity> : IRepository<TEntity>, IRepository
	{
		public List<TEntity> DataSource { get; set; }
		public Repository()
		{
			DataSource = new List<TEntity>();
		}
		public void Insert(TEntity entity)
		{
			DataSource.Add(entity);
		}
		void IRepository.Insert(object entity)
		{
			Insert((TEntity)entity);
		}
	}
