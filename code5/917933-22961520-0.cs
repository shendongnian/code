        string Type = null;
    
        for (int i = 0; i < chbCourse.Items.Count; i++)
        {
    
            if (chbCourse.Items[i].Selected == true)
            {
                Type += chbCourse.Items[i].ToString() + ",";
    
            }
        }
    
        if(Type != null)
            Type = Type.TrimEnd(',');
