    protected void btnAssignStudents_click(object sender, EventArgs e)
    {
        StudentDataContext db = new StudentDataContext();
        StudentCourse assigncourse = new StudentCourse();
        var course = db.Course_table.Where(cr=>cr.Course_Id == txtCourse_Id.Text).ToList();
        var student= db.student_table.Where(st=>st.Student_ID == txtStudentID.Text).ToList();
        if(course != null && course.Length > 0)
        {
            assigncourse.Course_Id = txtCourse_Id.Text;
            assigncourse.Student_ID = txtStudentID.Text;
            db.StudentCourses.InsertOnSubmit(assigncourse);
            db.SubmitChanges();
        }
    }
