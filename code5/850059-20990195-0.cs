    if (String.IsNullOrEmpty(textBox_project_name.Text))
        {
            Response.Write("<script>alert('Enter project name.')</script>");
        }
    
        if (String.IsNullOrEmpty(comboBox1_project_status.Text))
        {
            Response.Write("<script>alert('Enter project status.')</script>");
        }
    
        if (string.IsNullOrEmpty(dateTimePicker1.text))
        {
            Response.Write("<script>alert('Select Proper Date.')</script>");
        }
