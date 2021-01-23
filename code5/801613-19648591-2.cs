    // F - flat type
    // H - hiearchial type
    IEnumerable<H> MakeHierarchy<F,H>(
    	// Remaining items to process
    	IEnumerable<F> flat,
    	// Current "parent" to look for
    	object parentKey,
    	// Find key for given F-type
    	Func<F,object> key,
    	// Convert between types
    	Func<F,IEnumerable<H>,H> mapper,
    	// Should this be added as immediate child?
    	Func<F,object,bool> isImmediateChild) {
    
    	var remainder = flat.Where(f => !isImmediateChild(f, parentKey))
    		.ToList();
    	
    	return flat
    		.Where(f => isImmediateChild(f, parentKey))
    		.Select(f => {
    			var children = MakeHierarchy(remainder, key(f), key, mapper, isImmediateChild);
    			return mapper(f, children);
    		});
    }
    class category1
    {
        public int Id;
        public int ParentId;
        public string Name;
    	
    	public category1(int id, string name, int parentId) {
    		Id = id;
    		Name = name;
    		ParentId = parentId;
    	}
    };
    
    class category2
    {
        public int Id;
        public int ParentId;
        public string Name;
    	
    	public IEnumerable<category2> Subcategories = new List<category2>();
    };
    
    List<category1> categories = new List<category1>() {
        new category1(1, "Sport", 0),
        new category1(2, "Balls", 1),
        new category1(3, "Shoes", 1),
        new category1(4, "Electronics", 0),
        new category1(5, "Cameras", 4),
        new category1(6, "Lenses", 5),  
        new category1(7, "Tripod", 5), 
        new category1(8, "Computers", 4),
        new category1(9, "Laptops", 8),
        new category1(10, "Empty", 0),
        new category1(-1, "Broken", 999),
    };
    
    object KeyForCategory (category1 c1) {
    	return c1.Id;
    }
    
    category2 MapCategories (category1 c1, IEnumerable<category2> subs) {
    	return new category2 {
    		Id = c1.Id,
    		Name = c1.Name,
    		ParentId = c1.ParentId,
    		Subcategories = subs,
    	};
    }
    
    bool IsImmediateChild (category1 c1, object id) {
    	return c1.ParentId.Equals(id);
    }
    
    void Main()
    {
    	var h = MakeHierarchy<category1,category2>(categories, 0,
    		// These make it "Generic". You can use lambdas or whatever;
    		// here I am using method groups.
    		KeyForCategory, MapCategories, IsImmediateChild);
    	h.Dump();
    }
