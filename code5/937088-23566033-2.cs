    class Foo : IEnumerable
    {
        public void Add<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            
        }
        // ...
    }
	
    Foo foo = new Foo
	{
		{1, 2, 3},
        {2, 3, 4}
	};
