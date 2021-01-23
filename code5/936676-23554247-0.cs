    public enum ObjectState
    {
        Unchanged,
        Added,
        Deleted,
        Modified
    }
    public interface IObjectWithState
	{
		[NotMapped]
		[JsonIgnore]
		ObjectState ObjectState { get; set; }
	}
    public class Pet : IObjectWithState
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
