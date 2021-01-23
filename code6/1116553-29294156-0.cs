    private void SetPreviousCourseData()
        {
            int rowIndex = 0;
    
            if (ViewState["CurrentTableCourse"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableCourse"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList courseList = (DropDownList)Course_Gridview.Rows[rowIndex].Cells[1].FindControl("CourseList");
                        TextBox marks = (TextBox)Course_Gridview.Rows[rowIndex].Cells[2].FindControl("EnterMark");
    
                        courseList.Text = dt.Rows[i]["Column1Course"].ToString();
                        marks.Text = dt.Rows[i]["Column2Course"].ToString();
    
                        rowIndex++;
                    }
                }
            }
        }
