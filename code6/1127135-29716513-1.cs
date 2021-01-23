    DataTable table = GeneralHelper.GetUserIdByName(Session["User"].ToString(), Session["UserType"].ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultCSRConnection"].ConnectionString))
                    {
                        con.Open();
                        if (table != null && table.Rows.Count > 0)
                        {
                            string StudentId = GetNgoIdStudentId(dt.Rows[i]["Email Id"].ToString());
                            if (StudentId != null)
                            {
                                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_student_report(student_id,name,emailid,class,attendance,english_subject_marks,math_subject_marks,academic_performance,extra_activities,social_skills,general_health,date_of_record,modified_date,status,active) VALUES(@student_id,@name,@emailid,@class,@attendance,@english_subject_marks,@math_subject_marks,@academic_performance,@extra_activities,@social_skills,@general_health,@date_of_record,@modified_date,@status,@active)", con);
                                cmd.Parameters.Add("@NgoId", SqlDbType.Int).Value = table.Rows[0]["NgoId"].ToString();
                                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = StudentId;
                                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = dt.Rows[i]["Name"].ToString();
                                cmd.Parameters.Add("@emailid", SqlDbType.NVarChar).Value = dt.Rows[i]["Email Id"].ToString();
                                cmd.Parameters.Add("@class", SqlDbType.VarChar).Value = dt.Rows[i]["Class"].ToString();
                                cmd.Parameters.Add("@attendance", SqlDbType.Decimal).Value = dt.Rows[i]["Attendance"].ToString();
                                cmd.Parameters.Add("@english_subject_marks", SqlDbType.Int).Value = dt.Rows[i]["English Subject Marks"].ToString();
                                cmd.Parameters.Add("@math_subject_marks", SqlDbType.Int).Value = dt.Rows[i]["Maths Subject Marks"].ToString();
                                cmd.Parameters.Add("@academic_performance", SqlDbType.NVarChar).Value = dt.Rows[i]["Academic Performance"].ToString();
                                cmd.Parameters.Add("@extra_activities", SqlDbType.NVarChar).Value = dt.Rows[i]["Extra Activities"].ToString();
                                cmd.Parameters.Add("@social_skills", SqlDbType.NVarChar).Value = dt.Rows[i]["Social Skills"].ToString();
                                cmd.Parameters.Add("@general_health", SqlDbType.NVarChar).Value = dt.Rows[i]["General Health"].ToString();
                                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = dt.Rows[i]["Status"].ToString();
                                if (string.IsNullOrEmpty(dt.Rows[i]["Date Of Record"].ToString()))
                                {
                                    cmd.Parameters.Add("@date_of_record", SqlDbType.DateTime).Value = DateTime.Now;
                                }
                                else
                                {
                                    cmd.Parameters.Add("@date_of_record", SqlDbType.DateTime).Value = dt.Rows[i]["Date Of Record"].ToString();
                                }
                                if (string.IsNullOrEmpty(dt.Rows[i]["Modified Date"].ToString()))
                                {
                                    cmd.Parameters.Add("@modified_date", SqlDbType.DateTime).Value = DateTime.Now;
                                }
                                else
                                {
                                    cmd.Parameters.Add("@modified_date", SqlDbType.DateTime).Value = dt.Rows[i]["Modified Date"].ToString();
                                }
                                cmd.Parameters.Add("@active", SqlDbType.Bit).Value = dt.Rows[i]["Active"].ToString();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sheet uploaded successfully');window.location ='csrstudentprogress.aspx';", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Student not found');", true);
                            }
                        }
                        else
                        {
                            //Error
                        }
                    }
                }
