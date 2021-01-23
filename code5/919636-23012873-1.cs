      var _stud = context.Students
            .Where(p => p.studID == "001").ToList();
        foreach (var item in _stud)
	{
	 if (_stud != null)
           {
            var _course = _stud.Courses.ToList();
             if (_course != null)
              {
                foreach (var item2 in _course)
	         {
		  
                  _course.Students.Remove(item2);
                  context.SaveChanges();
           
	         }
              }
           
          }
       }
     }
