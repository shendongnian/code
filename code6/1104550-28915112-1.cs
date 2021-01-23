    public static void Main()
	{
		var pack = 1 == 1 ? (IPack)new PackTypeA() : (IPack)new PackTypeB();
		pack.AbstractMethod1();
		pack = 1 == 2 ? (IPack)new PackTypeA() : (IPack)new PackTypeB();
		pack.AbstractMethod1();
	}
	public interface IPack { void AbstractMethod1(); }
	public abstract class PackEntry { }
	public sealed class PackEntryTypeA : PackEntry {}
	public sealed class PackEntryTypeB : PackEntry {}
	public abstract class Pack<T> : IPack where T : PackEntry
	{
		protected List<T> m_Entries = new List<T>();
		public abstract void AbstractMethod1();
	}
	public sealed class PackTypeA : Pack<PackEntryTypeA> 
	{
		public override void AbstractMethod1() 
		{ 
			Console.WriteLine(m_Entries.GetType().ToString());
		}
	}
	public sealed class PackTypeB : Pack<PackEntryTypeB> 
	{
		public override void AbstractMethod1() 
		{ 
			Console.WriteLine(m_Entries.GetType().ToString());
		}
	}
