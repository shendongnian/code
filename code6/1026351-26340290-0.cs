    int k = 0;
    while(!String.IsNullOrEmpty(coursename[k]))
    {
        if (coursename[k].Contains(CourseEditNameTextBox.Text))
        {
            nameerror.Visible = true;
            Break;
        }
        else
        {
            nameerror.Visible = false;
        }
        k++;
    }
