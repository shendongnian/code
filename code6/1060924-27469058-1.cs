      bool hasErrorFlag = false; // use Error Flag
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        hasErrorFlag = true; // Error Flag updated
                    }
      }
      // Put outside the messagebox message for success or failure
      if (hasErrorFlag == false)
         {
             MessageBox.Show("Subjects table has been updated successfully!");
         }
      else
         {
             MessageBox.Show("StudentBio table has not been updated! ");
         }
