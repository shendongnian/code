    void textBox_project_name_Validating(object sender, CancelEventArgs e)
    {
        if (String.IsNullOrEmpty(textBox_project_name.Text))
        {
           e.Cancel = true;
           errorProvider1.SetError(textBox_project_name, "Required");   
        }
        else
        {
           errorProvider1.SetError(textBox_project_name, "");  
        }
    }
