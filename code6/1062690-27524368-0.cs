	public interface IVersionedClass
	{
		int Variable1 { get; set; }
		string Variable2 { get; set; }
	}
	public class ClassVersion1 : IVersionedClass
	{
		public int Variable1 { get; set; }
		public string Variable2 { get; set; }
	}
	public class ClassVersion2 : IVersionedClass
	{
		public int Variable1 { get; set; }
		public string Variable2 { get; set; }
	}
