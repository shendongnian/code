      for (int i = 0; i < listViewSubject.Items.Count; i+=2)
            {
             string query = "INSERT INTO Std_Subjects (subject_id, std_reg_id) VALUES (@subjectID,@StdRegId)";
             SqlCommand command = new SqlCommand(query, connection);
             command.Parameters.AddWithValue("@subjectID",Int.Parse(listViewSubject.Items[i].Text));
             command.Parameters.AddWithValue("@StdRegId", this.reg_id);
             command.ExecuteNonQuery();
            }
