    protected void btnAssignStudents_click(object sender, EventArgs e)
    {
        var db = new StudentDataContext();
       
        // check whether both course and student with specified ID's exist
        // make sure txtCourse_Id.Text and txtStudentID.Text is not null or empty
        if (db.StudentsCourses.Any(c => c.Id == txtCourse_Id.Text 
            && db.Students.Any(s => s.Id == txtStudentID.Text)
        {
            var assigncourse = new StudentCourse();
            assigncourse.Course_Id = txtCourse_Id.Text;
            assigncourse.Student_ID = txtStudentID.Text;
            db.StudentCourses.InsertOnSubmit(assigncourse);
            db.SubmitChanges();
        }
    }
