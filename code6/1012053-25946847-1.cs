    public class TeacherCanAccessOrdersQuery : ICanAccessQuery<Teacher, Order>
	{
		public bool CanView(Teacher user, Order entity)
		{
			var predicate = PredicateBuilder.Create<Order>(x => x.Id == entity.Id && x => x.Account.Id == user.Account.Id);
			return RepositoryProvider.Get<Order>().Count(predicate) > 0;
		}
		public bool CanEdit(Teacher user, Order entity)
		{
			// similar implementation
		}
	}
    
