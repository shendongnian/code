    for (int i = 0; i < gvSubjectsList.Rows.Count; i++)      
        {
            CheckBox chkSelect = (CheckBox)gvSubjectsList.Rows[i].FindControl("checkboxid");
            Label SubjectId = (Label)gvSubjectsList.Rows[i].FindControl("SubjectId");
            if (chkSelect.Checked == true)
            {
                olist.Add(SubjectId.Text);
            }
        }
