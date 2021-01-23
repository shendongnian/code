    TestClass[] originalEnumerable
       = Enumerable.Range(1, 1).
                    Select(x => new TestClass() { Num = x, Name = x.ToString() })
                    .ToArray();
    
    List<TestClass> listFromEnumerable = originalEnumerable.ToList();
    
    // true
    bool test = ReferenceEquals(listFromEnumerable[0], originalEnumerable[0]); 
