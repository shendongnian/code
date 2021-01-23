            try
            {
                using (var db = new SqlConnection("connection string"))
                using (var transaction = db.BeginTransaction())
                using (var cmd = db.CreateCommand())
                {
                    cmd.Transaction = transaction;
                    db.Open();
                    cmd.CommandText = "insert into StudentDetails(StudentName, DOB, Description, Gender) values(@name, @dob, @desc, @gender)";
                    cmd.Parameters.AddWithValue("@name", sd.StudentName);
                    cmd.Parameters.AddWithValue("@dob", sd.DOB);
                    cmd.Parameters.AddWithValue("@desc", sd.Description);
                    cmd.Parameters.AddWithValue("@gender", sd.Gender);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    // other queries
                    transaction.Commit();
                }
            }
            catch (SqlException ex)
            {
                string s = ex.Message.ToString();
            }
