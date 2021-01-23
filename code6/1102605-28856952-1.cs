	Course firstCourse;
	using (var context = new TestContext())
	{
		firstCourse = context.Courses.First();
	}
	Console.WriteLine("Course {0} has {1} modules", firstCourse.Title, 
        firstCourse.Modules.Count);    // ObjectDisposedException when Modules tries to lazy load
