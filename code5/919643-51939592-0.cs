    using(var context = new DBEntities())
	{    
		// Get student by id
		var student = context.Students.Include(s => s.Courses).Where(s => s.studID == "001").FirstOrDefault();
		
		if(student.Courses != null)
		{
			// Retrieve list of courses for that student
			var coursesToRemove = stud.Courses.ToList();
			
			// Remove courses
			foreach (var course in coursesToRemove)
			{
				student.Courses.Remove(course);
			}
			
			// Save changes
			context.SaveChanges();
		}
	}
