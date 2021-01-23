    var colleges =   db.Colleges
    				   .Select(x => new OurCollege()
    				   {
    						CollegeId = x.CollegeId,
    						Name = x.Name,
    						Contact = x.Contact
    				   }).ToList();
    				   
    foreach (var college in colleges)
    {
    		college.MyCourse =  db.Course.Where(x => x.CollegeId == college.CollegeId)
    		                      .Select(x => new OurCourse()
    							  {
    							     Name = x.Name,
    								 NumberOfYears = x.Years
    							  }).ToList()
    }
