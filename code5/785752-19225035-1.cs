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
    
                   
                }
            
            }
        }
