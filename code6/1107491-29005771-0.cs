	class ReadonlyClass
	{
		private string p1;
		private int p2;
		public ReadonlyClass(string property1, int property2)
		{
			p1 = property1;
			p2 = property2;
		}
		public string Property1
		{
			get { return p1; }
		}
		public int Property2
		{
			get { return p2; }
		}
	}
