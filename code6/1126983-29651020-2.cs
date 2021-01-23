    var qry = new List<object>();
	foreach (var cs in db.Courses.Where(c => c.CourseCode == "@CourseCode"))
	{
		foreach (var inst in db.Instructors)
		{
			if (inst.CourseId == cs.CourseId)
			{
				qry.Add(new 
				{
					cs.CourseCode,
					cs.CourseName,
					cs.CourseAbout,
					cs.CourseObjectives,
					cs.CourseLearningOut,
					inst.InstructorName,
					cs.CourseImgUrl,
                }); 
			}
		}
	}
