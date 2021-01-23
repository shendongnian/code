                insertNewUsers.CommandType = CommandType.StoredProcedure;
                insertNewUsers.Parameters.Add("@ApplicationName", SqlDbType.NVarChar, 256).Value = AppName;
                insertNewUsers.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = UserName;
                insertNewUsers.Parameters.Add("@Password ", SqlDbType.NVarChar, 128).Value = pwd;
                insertNewUsers.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar, 128).Value = string.Empty;
                insertNewUsers.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value = Email;
                //  insertNewUsers.Parameters.Add(("@LoweredEmail"), SqlDbType.NVarChar, 256).Value = (Email.Text).ToLower();
                insertNewUsers.Parameters.Add("@PasswordQuestion", SqlDbType.NVarChar, 256).Value = DBNull.Value;
                insertNewUsers.Parameters.Add("@PasswordAnswer", SqlDbType.NVarChar, 128).Value = DBNull.Value;
                insertNewUsers.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = 1;
                // insertNewUsers.Parameters.Add("@IsLockedOut", SqlDbType.NVarChar, 1).Value = 0;
                insertNewUsers.Parameters.Add("@CurrentTimeUtc", SqlDbType.DateTime).Value = DateTime.UtcNow.Date;
                insertNewUsers.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = DateTime.Today.ToLocalTime();
                insertNewUsers.Parameters.Add("@UniqueEmail", SqlDbType.Int).Value = 0;
                insertNewUsers.Parameters.Add("@PasswordFormat", SqlDbType.Int).Value = 0;
                // Create parameter with Direction as Output (and correct name and type)
                SqlParameter outputUserIdParam = new SqlParameter("@UserId", SqlDbType.UniqueIdentifier)
                {
                    Direction = ParameterDirection.Output
                };
                insertNewUsers.Parameters.Add(outputUserIdParam);
                pID = insertNewUsers.Parameters.Add("@return_value", SqlDbType.Int);
                pID.Direction = ParameterDirection.ReturnValue;
