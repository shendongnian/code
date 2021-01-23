    for (int i = 0; i < chbCourse.Items.Count; i++)
    {
        if (chbCourse.Items[i].Selected == true)
        {
            if (i == chbCourse.Items.Count - 1) Type += chbCourse.Items[i].ToString() + ".";
            else 
               Type += chbCourse.Items[i].ToString() + ",";
        }
    }
