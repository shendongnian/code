    	[Test]
		public void Mapper()
		{
			var course = new Course { Name = "just a simple name" };
			var applicantList = new List<Applicant>()
				{
					new Applicant {Course = course, CourseId = 1, Name = "Applicant Course 1"}, 
					new Applicant {Course = course, CourseId = 2, Name = "Applicant Course 2"}
				};
			course.Applicants = applicantList;
            
			var courseView = new CourseListViewModel();
			courseView.InjectFrom<FlatLoopValueInjection>(course);
            //just set other props here, like you did with AutoMapper.
			courseView.Applicants = course.Applicants.Count;
			
			var applicantViewList = applicantList.Select(s =>
				{
					var applicantView = new ApplicantListViewModel();
					applicantView.InjectFrom<FlatLoopValueInjection>(s);
					return applicantView;
				}).ToList();
			
			Assert.AreEqual(course.Name, courseView.Name);
			Assert.AreEqual(course.Applicants.Count, courseView.Applicants);
			Assert.AreEqual(applicantList[0].Name, applicantViewList[0].Name);
			Assert.AreEqual(applicantList[0].Course.Name, applicantViewList[0].CourseName);
		}
