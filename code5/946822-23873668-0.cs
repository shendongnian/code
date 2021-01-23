    // Initialization of "tests", class definition, etc.
     
    List<Test> firsts = tests.Where(x => x.Sort == Sort.First ).ToList(); 		
    List<Test> others = tests.Where(x => x.Sort != Sort.First ).ToList();		 		
    List<Test> result = firsts.AddRange(others).ToList();
