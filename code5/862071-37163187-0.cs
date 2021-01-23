    [ProtoContract]
	public class Parent
	{
		[ProtoMember(1)]
		public List<Child> Children
		{
			get { return m_Children; }
			set { m_Children = value; }
		}
		private List<Child> m_Children = new List<Child>();
	}
	[ProtoContract]
	public class Child
	{
		[ProtoMember(1, AsReference = true)]
		public Parent Parent
		{
			get { return m_Parent; }
			set { m_Parent = value; }
		}
		[ProtoMember(2)]
		public int Index
		{
			get { return m_Index; }
			set { m_Index = value; }
		}
		Parent m_Parent;
		int m_Index;
	}
