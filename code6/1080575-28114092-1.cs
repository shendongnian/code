	public abstract class Class2
	{
		public DateTime Added { get; protected set; }
		public int ID { get; protected set; }
	}
	public class Class1 : Class2
	{
		public string ImageFilename { get; set; }
		public string LinkText { get; set; }
	}
