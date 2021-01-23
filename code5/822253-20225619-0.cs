	public interface IGroup
	{
		Guid ID { get; }
		String Title { get; }
		IEnumerable<IStudent> Students { get; }
		void AddStudent(IStudent student);
	}
