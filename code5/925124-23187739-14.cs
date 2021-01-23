	public class Entity :
		ICreatableEntity,
		IRemovableEntity {
		#region ICreatableEntity Members
		public DateTime CreatedDateTime { get; set; }
		public virtual Employee CreatedBy { get; set; }
		#endregion
		#region IRemovableEntity Members
		public bool IsRemoved { get; set; }
		public int? RemovedById { get; set; }
		public DateTime? RemovedDateTime { get; set; }
		public virtual Employee RemovedBy { get; set; }
		#endregion
		public Entity() {
			this.CreatedDateTime = DateTime.Now;
		}
	}
