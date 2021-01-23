    'SqlConnection objCon = new SqlConnection(con);
                    objCon.Open();
                    SqlCommand cmd = new SqlCommand("Studentinsertadmission", objCon);
      cmd.Parameters.Add(new SqlParameter("@Studentid",Convert.ToInt32( studentid.Text)));
                    cmd.Parameters.Add(new SqlParameter("@StudentName", firstname.Text));
                    cmd.Parameters.Add(new SqlParameter("@Image", image.image  ));
    cmd.CommandType = CommandType.StoredProcedure;
                    int rows = cmd.ExecuteNonQuery();
                    objCon.Close();
                    
                    MessageBox.Show("Record Inserted Successfully! ");'
    Try this it works deppending on the component.
