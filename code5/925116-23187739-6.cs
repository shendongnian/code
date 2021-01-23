	public interface ICreatableEntity {
		Employee CreatedBy { get; set; }
		DateTime CreatedDateTime { get; set; }
	}
	public interface ICreatableEntity<TKey> :
		ICreatableEntity {
		TKey CreatedById { get; set; }
	}
