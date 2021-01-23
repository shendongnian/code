    for (int i = 0; i < addcrsView.Rows.Count; i++)
    {
    StrQuery = @"INSERT INTO student_reg VALUES (@id,@CourseName,@Credits)";
    comm.CommandText = StrQuery;
    comm.Parameters.AddWithValue("@id",id);
    comm.Parameters.AddWithValue("@CourseName",addcrsView.Rows[i].
                                                  Cells["Course Name"].Value);
    comm.Parameters.AddWithValue("@Credits",addcrsView.Rows[i].
                                                  Cells["Credit"].Value);
    if (comm.ExecuteNonQuery() > 0)
    {
       MessageBox.Show("inserted");
    }
    else
    {
       MessageBox.Show("Not insert");
    }
    
    comm.Parameters.Clear();
    }
