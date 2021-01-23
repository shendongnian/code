    Dictionary<A, List<B>> objAwithB = new Dictionary<A, List<B>>();
    B objB = new B();
    objB.Prop1 = "AAA";
    
    objAwithB.Where(g => g.Value.Any(x => x.Prop1 == objB.Prop1))
             .Select(g => g.Key)
             .ToList();   
