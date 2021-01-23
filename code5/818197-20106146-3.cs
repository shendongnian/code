    public boolean SaveDuplicatCourse()
    {
        if(con.State !=ConnectionState.Open)
            con.Open();
        List<int> IDs = new List<int>();
        foreach (DataGridViewRow r in dataGridViewStudents.Rows)
        {
            if (r.Cells[0].Value != null && bool.Parse(r.Cells[0].Value.ToString()))
            {
                IDs.Add(int.Parse(r.Cells[1].Value.ToString()));
            }
        }
        foreach (int i in IDs)
        {
           try
           {
              SqlCommand com = new SqlCommand(@"Insert into DuplicateCourses 
                 values(" + i + "," + CCID + ")", con);
              com.ExecuteNonQuery();
           }
           catch (Exception)
           {
              MessageBox.Show("They are exist");
              saveDuplicateCourseCompleted=false// Now this is right way
           }
        }
        con.Close();
        
    }
