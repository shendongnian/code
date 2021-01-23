	Subject subjectEntity = subjects
		.Where(s => s.Name == input)
		.FirstOrDefault();
	List<Tutor> tutorsList = tutors
		.Where(t => t.Subjects
			.Select(x => x.SubjectId)
			.Contains(subjectEntity.SubjectId)
		)
		.ToList();
