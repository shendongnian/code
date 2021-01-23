    if (qry.Any())
    {
            LblCourseName.Text = qry.FirstOrDefault().CourseName;
            LblCourseAbout.Text = qry.FirstOrDefault().CourseAbout;
            LblObjectives.Text = qry.FirstOrDefault().CourseObjectives;
            LblLearningOutcomes.Text = qry.FirstOrDefault().CourseLearningOut;
            LblCourseInstructore.Text = qry.FirstOrDefault().InstructorName;
      
    }
