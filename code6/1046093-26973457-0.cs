	class Test : IEnumerable<Test>
	{
		IEnumerator<Test> IEnumerable<Test>.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
        ...
	var test = new Test();
	CallFirst(test);
