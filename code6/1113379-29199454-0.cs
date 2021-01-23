    public List<string> FillTreeLesson(string course_id)
    {
    List<string> returnList = new List<string>(); 
        try
        {
               
            con.Open();
            MySqlCommand cmnd = con.CreateCommand();    
            string sql = "select name from lesson where course like '%"+course_id+"%'";
            cmnd.CommandText = sql;
            MySqlDataReader reader = cmnd.ExecuteReader();
        
        while (reader.Read())
        {
              lesson_name = reader.GetString("name");
              returnList.Add(lesson_name);
        }
        con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    
      return returnList;
    }
