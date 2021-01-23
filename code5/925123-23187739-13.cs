	public interface IRemovableEntity {
		bool IsRemoved { get; set; }
		int? RemovedById { get; set; }
		DateTime? RemovedDateTime { get; set; }
		Employee RemovedBy { get; set; }
	}
