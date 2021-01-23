    using (connection = new SqlConnection(Auth2Manager.getAuthConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO " + Tables.TABLE_USERS + " (" + Columns.USER_NAME + ","
                        + Columns.PASSWORD + "," + Columns.TOKEN + ","
                        + Columns.CREATED_DATE + "," + Columns.UPDATED_DATE + "," + Columns.UPDATED_BY
                        + "," + Columns.IS_ACTIVE + "," + Columns.APP_ID + ")" +
                    " VALUES (@UserName, @Password, @Token, @CreatedDate, @UpdatedDate, @UpdatedBy, @IP, @IsActive, @AppId)");
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    string token = Helper.generateUniqueToken();
                    tokenGenerated = token; 
                    Console.WriteLine(token);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Token", token);
                    dateNow = DateTime.Now;
                    date = dateNow.Year.ToString() + "-" + dateNow.Month.ToString() + "-" + dateNow.Day.ToString();
                    cmd.Parameters.AddWithValue("@CreatedDate", date);
                    cmd.Parameters.AddWithValue("@UpdatedDate", date);
                    cmd.Parameters.AddWithValue("@UpdatedBy", user.UserName);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    cmd.Parameters.AddWithValue("@AppId", user.ApplicationID);
                    connection.Open();
                    resultCount = cmd.ExecuteNonQuery();
                }
                if (resultCount > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            else {
                tokenGenerated = null;
                return false;
            }
