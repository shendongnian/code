      foreach(string subject in subjects)
      {
        //your update here
        SQLString2 = "UPDATE subjects SET program = @ProgramU, faculty = @FacultyU, subjectN = @SUBJECT WHERE RollNo = " + Convert.ToInt32(this.rollNumber7_combo.SelectedItem.ToString()) + " AND regYear = " + Convert.ToInt32(this.comboBox3.SelectedItem.ToString()) + " AND program = '" + this.comboBox1.SelectedItem.ToString() + "' AND faculty = '" + this.comboBox2.SelectedItem.ToString() + "'";
        SQLCommand.Parameters.AddWithValue("@SUBJECT", subject);
        
        // And by the way put inside this bracket the execution of this query
        SQLCommand.CommandText = SQLString2;
                    SQLCommand.Connection = database;
                    int response2 = -1;
                    try
                    {
                        response2 = SQLCommand.ExecuteNonQuery();
                        if (response2 > 0)
                        {
                            MessageBox.Show("subjects table has been updated successfully!");
                        }
                        else
                            MessageBox.Show("studentBio table has not been updated!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
      }
