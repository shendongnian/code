    private void CreateParameterList(ref Student s, ref SqlCommand cmd)
               {
                  var parameters = new []
                                       {
                                         new SqlParameter("@FirstName",s.FirstName),
                                         new SqlParameter("@LastName",s.LastName),
                                         :
                                         :
                                          new SqlParameter("@ContactNumber",s.ContactNumber)
                                        }
                  cmd.Parameters.AddRange(parameters);
               }
