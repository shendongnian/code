     protected void btnAssignStudents_click(object sender, EventArgs e)
        {
            int CourseId=Convert.ToInt32(txtCourse_Id.Text);
            int StudentID=Convert.ToInt32(txtStudentID.Text);
        
            StudentDataContext db = new StudentDataContext();
            StudentCourse assigncourse = new StudentCourse();
            var _studentcourse = db.StudentCourse.Where(sc=>sc.Course_Id == CourseId && sc.Student_ID == StudentID).FirstOrDefault();          
            if(_studentcourse  != null && (db.Courses.Any(c => c.Course_Id == CourseId
            && db.Students.Any(s => s.Student_Id ==StudentID) )
            {
                assigncourse.Course_Id =CourseId;
                assigncourse.Student_ID = StudentID;
                db.StudentCourses.InsertOnSubmit(assigncourse);
                db.SubmitChanges();
            }
        }
