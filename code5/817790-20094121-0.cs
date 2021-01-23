    class Tree: IHierarchicalEnumerable
	{
		public int ID { get; set; }
		public int Value1 { get; set; }
		public int ParentID { get; set; }
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
		public IHierarchyData GetHierarchyData(object enumeratedItem)
		{
			throw new NotImplementedException();
		}
	}
