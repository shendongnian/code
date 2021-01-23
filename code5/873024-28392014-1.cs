	public sealed class MyDb : IDisposable
	{
		private MyContext _context;
		public MyDb(string connectionString, Lazy<Guid?> currentUserIdFunc)
		{
			this._context = new MyContext(connectionString);
			Database.SetInitializer<MyContext>(new DatabaseInitializer());
			this._context.Database.Initialize(true);
			this._currentUserIdFunc = currentUserIdFunc;
		}
		public async Task<T> GetEntityAsync<T>(Func<IQueryable<T>, IQueryable<T>> entityQuery) where T : class, IDbEntity
		{
			var query = entityQuery(this._context.Set<T>());
			if (typeof(T) is IDbAuditable)
			{
				query = query.Cast<IDbAuditable>()
					 .Where(a => !a.DeletedById.HasValue)
					 .Cast<T>();
			}
			return await query.FirstOrDefaultAsync();
		}
		public async Task<int> UpdateAsync<T>(T entity) where T : class, IDbEntity
		{
			if (entity is IDbDoNotModify)
			{
				throw new DoNotModifyException("Entity cannot be Modified (IDoNotModify).");
			}
			this._context.Set<T>().Attach(entity);
			var entry = this._context.Entry<T>(entity);
			entry.State = EntityState.Unchanged;
			var entityType = entity.GetType();
			var metadata = entityType.GetCustomAttributes(typeof(MetadataTypeAttribute)).FirstOrDefault() as MetadataTypeAttribute;
			if (metadata != null)
			{
				var type = metadata.MetadataClassType;
				var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
					 .Select(p => new
					 {
						 Name = p.Name,
						 ScaffoldColumn = p.GetCustomAttributes(typeof(ScaffoldColumnAttribute), true).FirstOrDefault() as ScaffoldColumnAttribute,
						 Readonly = entityType.GetProperty(p.Name).GetCustomAttributes(typeof(ReadOnlyAttribute), true).FirstOrDefault() as ReadOnlyAttribute
					 })
					 .Where(p => p.ScaffoldColumn == null || p.ScaffoldColumn.Scaffold)
					 .ToList();
				foreach (var property in properties)
				{
					entry.Property(property.Name).IsModified = true;
				}
			}
			else
			{
				entry.State = EntityState.Modified;
			}
			var auditable = entity as IDbAuditable;
			if (auditable != null)
			{
				this.Modified(auditable, this._currentUserIdFunc.Value);
				entry.Property("ModifiedOn").IsModified = true;
				entry.Property("ModifiedById").IsModified = true;
			}
			return await this._context.SaveChangesAsync();
		}
		private void Modified(IDbAuditable instance, Guid? currentUserId)
		{
			instance.ModifiedById = currentUserId.Value;
			instance.ModifiedOn = DateTime.Now;
		}
	}
