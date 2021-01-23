	public class Int32Entity :
		Entity,
		ICreatableEntity<int>,
		IIndexableEntity<int> {
		#region ICreatableEntity`TKey Members
		public int CreatedById { get; set; }
		#endregion
		#region IIndexableEntity Members
		public int Id { get; set; }
		#endregion
	}
