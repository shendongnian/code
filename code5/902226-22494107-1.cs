    string StudentIDLabel = ((Label)(e.Item.FindControl("StudentIDLabel"))).Text.Trim();
	string CourseIDLabel = ((Label)(e.Item.FindControl("CourseIDLabel"))).Text.Trim();
	string GradeLabel = ((Label)(e.Item.FindControl("GradeLabel"))).Text.Trim();
	AccessDataSource1.DeleteCommand = "DELETE FROM [CoursesTaken] WHERE [StudentID] = '" + StudentIDLabel + "' AND [CourseID] = '" + CourseIDLabel + "' AND [Grade] ='" + GradeLabel + "'";
	AccessDataSource1.Delete();
	AccessDataSource1.DataBind();
