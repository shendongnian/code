    return View(data.Select(x => new TestDataViewModel
    	{
            //rewrite your TestDataLog properties to corresponding TestDataViewModel properties
    		Prop1 = x.Prop1
    		//etc
    	}
     ).ToList());
