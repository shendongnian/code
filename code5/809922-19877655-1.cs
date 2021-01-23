    void UpdateLessonTable()
    {
         SqlConnection cnn = new SqlConnection();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           SqlCommandBuilder cb = new SqlCommandBuilder(da);
           DataSet ds = new DataSet();
            cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Project1ConnectionString"].ConnectionString;
            cnn.Open();
        
            cmd.CommandText = "select * from  Lesson";
            cmd.Connection = cnn;
        
            da.SelectCommand = cmd;
        
            da.Fill(ds, "Lesson");
        
         if (!checkDuplicateTitle(ds.Tables["Lesson"].Rows, textBox1.Text.ToString()))
            {
            DataRow drow = ds.Tables["Lesson"].NewRow();
        
            drow["TopicID"] = DropDownList1.Text;
            drow["LessonTitle"] = TextBox1.Text;
            drow["LessonDate"] = DateTime.Now;
            ds.Tables["Lesson"].Rows.Add(drow);
            da.Update(ds, "Lesson");
            }
           else
            {
             //you can display some warning here
             // MessageBox.Show("Duplicate Lesson Title!");
            }
    }
    //function for checking duplicate LessonTitle
    bool checkDuplicateTitle(DataRowCollection rowTitle,String newTitle)
            {
                foreach (DataRow row in rowTitle)
                {
                   if(row["LessonTitle"].Equals(newTitle))
                    return true;
                }
                return false;
            }
