      protected void Exam_ClickHandler(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvDoctorList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                if (chk.Checked)
                {
                    string patientId = ((Label)row.FindControl("lblPID")).Text;
                    string exam = ((Button)sender).Text;
    
                    ///your insertion query goes here.
                    ///
    
                    GetPatientExams(patientId);
                }
            
            }
        }
    
        protected void Patient_ExamHandler(object sender, CommandEventArgs e)
        {
            string patientId = e.CommandArgument.ToString();
            GetPatientExams(patientId);
    
          
        }
    
  
      private void GetPatientExams(string pid)
    {
    
        DataTable exams = "Get exam data from db by pid";
    
        dtlExams.DataSource = exams;
        dtlExams.DataBind();
    
