	public static void Main()
	{
        // original query but without _context
		var LectureReportStudent = GetLectureReportStudent();
        List<StudentModel> testList = LectureReportStudent
            .Select(x => new StudentModel
            {
                Name = x.Student.FirstName + " " + x.Student.LastName,
                Position = x.Student.JobTitle,
                JobId = x.LectureReport.LectureId,
                StudentId = x.StudentlId,
                LectureId = x.LectureReportId,
                Date = x.Date
            }).ToList();
        // second query, guessing what tstPData is
		var tstPData = testList;
		var result = tstPData.GroupBy(x => x.StudentId);
		foreach(var r in result)
		{
			Console.WriteLine(r.Key + " " + r.Count());
		}
	}
