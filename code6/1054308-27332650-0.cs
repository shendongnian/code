    /// <summary>
            /// Returns the stored value for the given key or <c>null</c> if the matching file (<see cref="GenerateStoredKey"/>
            /// in <see cref="FolderPath"/> doesn't exist.
            /// </summary>
            /// <typeparam name="T">The type to retrieve</typeparam>
            /// <param name="key">The key to retrieve from the data store</param>
            /// <returns>The stored object</returns>
            public Task<T> GetAsync<T>(string key)
            {
                //Key is the user string sent with AuthorizeAsync
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException("Key MUST have a value");
                }
                TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
    
    
                // Note: create a method for opening the connection.
                SqlConnection myConnection = new SqlConnection("user id=" + LoginName + ";" +
                                          @"password=" + PassWord + ";server=" + ServerName + ";" +
                                          "Trusted_Connection=yes;" +
                                          "database=" + DatabaseName + "; " +
                                          "connection timeout=30");
                myConnection.Open();
    
                // Try and find the Row in the DB.
                using (SqlCommand command = new SqlCommand("select RefreshToken from GoogleUser where UserName = @username;", myConnection))
                {
                    command.Parameters.AddWithValue("@username", key);
    
                    string RefreshToken = null;
                    SqlDataReader myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        RefreshToken = myReader["RefreshToken"].ToString();
                    }
    
                    if (RefreshToken == null)
                    {
                        // we don't have a record so we request it of the user.
                        tcs.SetResult(default(T));
                    }
                    else
                    {
    
                        try
                        {
                            // we have it we use that.
                            tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(RefreshToken));
                        }
                        catch (Exception ex)
                        {
                            tcs.SetException(ex);
                        }
    
                    }
                }
    
                return tcs.Task;
            }
