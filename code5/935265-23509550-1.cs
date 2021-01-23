                    using (SqlConnection conn = SQL.GeSQLConnection())
                    {
                        String sql = "Select DueDate from tbl_AssignmentUpload1 where AssignmentTitle like '" + AssignmentTitle + "'";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader dr = cmd.ExecuteReader();
                        DateTime duedate = new DateTime();
                        if (dr != null && dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                duedate = dr.GetDateTime(0);
                            }
                            dr.Close();
                            // now check if today greater than due date and update
                           if(duedate != null && DateTime.Today > duedate)
                           {
                            sql = "Insert into tbl_AssignmentSubmit( Name ,AridNumber, Shift , Degree , Course , FileName ,FilePath ) values ('" + txt_Name.Text + "' , '" + txt_AridNumber.Text + "', '" + shift +"', '" + Degree + "', '" + Course + "','" + FileName + "','" + FilePath + "')";
                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                          }
                          else
                          {
                            lbl_uploaded.Text = "Assignment can not be Submitted.You crossed the due date.";
                          }
                        }
                    }
