	[TestFixture]
	class LinqPerformanceTest
	{
		private List<int> m_intList; 
		[SetUp]
		public void SetUp()
		{
			m_intList = new List<int>();
			for (int i = 0; i < 10000; i++)
			{
				m_intList.Add(i);
			}
		}
		[Test]
		[Repeat(5000)]
		public void LoopWithForeach()
		{
			StringBuilder b = new StringBuilder();
			
			foreach (int v in m_intList)
			{
				b.Append(v.ToString(CultureInfo.InvariantCulture));
			}
		}
		[Test]
		[Repeat(5000)]
		public void LoopWithFor()
		{
			StringBuilder b = new StringBuilder();
			for (int j = 0; j < m_intList.Count; j++)
			{
				int v = m_intList[j];
				b.Append(v.ToString(CultureInfo.InvariantCulture));
			}
		}
		[Test]
		[Repeat(5000)]
		public void LoopWithLinq()
		{
			StringBuilder b = new StringBuilder();
			for (int j = 0; j < m_intList.Count(); j++)
			{
				int v = m_intList.ElementAt(j);
				b.Append(v.ToString(CultureInfo.InvariantCulture));
			}
		}
		[Test]
		[Repeat(100)]
		public void LoopWithLinq2()
		{
			StringBuilder b = new StringBuilder();
			var myEnumerator = new MyEnumerableWrapper<int>(m_intList);
			for (int j = 0; j < myEnumerator.Count(); j++)
			{
				int v = myEnumerator.ElementAt(j);
				b.Append(v.ToString(CultureInfo.InvariantCulture));
			}
		}
		private class MyEnumerableWrapper<T> : IEnumerable<T>
		{
			private readonly IEnumerable<T> m_innerEnum;
			public MyEnumerableWrapper(IEnumerable<T> innerEnum)
			{
				m_innerEnum = innerEnum;
			}
			public IEnumerator<T> GetEnumerator()
			{
				return m_innerEnum.GetEnumerator();
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}		
	}
