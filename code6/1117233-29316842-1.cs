    bool bLoading = false;
    
    {
        dt = db.getCourses(depID, academicYearValue, semID);
        if (dt.Tables[0].Rows.Count > 0)
        {
            bLoading = true;
            try
            {
                dropdownCourses.DataSource = dt.Tables[0];
                dropdownCourses.DisplayMember = "Course";
                dropdownCourses.ValueMember = "ID";
            }
            catch{}
            finally{
                bLoading = false; //make sure that this variable must be false after populating combobox otherwise event will not work
            }
        }
    }
    
    private void dropdownCourses_SelectedValueChanged(....)
    {
        if (!bLoading)
        {
            Write your code here.
        }
    }
