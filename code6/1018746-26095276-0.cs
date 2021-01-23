    var newTests = tests.Where(test => ids.Contains(test.ID))
                        .Select(test => { 
                                           test.Name = null; 
                                           return test;
                                        });
