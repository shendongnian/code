	public bool CheckAssessment(string assessmentName)
	{
		return (from b in contxt.View_Assessment
			where b.AssessmentName == assessmentName
			select b).Count() > 0;
	}
