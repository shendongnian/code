    protected void btnAssignStudents_click(object sender, EventArgs e)
        {
               int CourseId=Convert.ToInt32(txtCourse_Id.Text);
                int StudentID=Convert.ToInt32(txtStudentID.Text);
    
            StudentDataContext db = new StudentDataContext();
            StudentCourse assigncourse = new StudentCourse();
            
            var _student= db.student_table.Where(s=>s.Student_ID == StudentID && s.Course_table.Student_ID ==StudentID ).FirstOrDefault();
            if( _student != null)
            {
                
                assigncourse.Course_Id =CourseId;
                assigncourse.Student_ID = StudentID;
                db.StudentCourses.InsertOnSubmit(assigncourse);
                db.SubmitChanges();
            }
        }
