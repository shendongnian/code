	public abstract class Class2
	{
		protected DateTime Added { get; private set; }
		protected int ID { get; private set; }
	}
	public class Class1 : Class2
	{
		public string ImageFilename { get; set; }
		public string LinkText { get; set; }
	}
