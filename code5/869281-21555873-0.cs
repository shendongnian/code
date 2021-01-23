        PrincipalContext AD = new PrincipalContext(ContextType.Domain, "[my domanin]", "[my path]");
                UserPrincipal ADUser = new UserPrincipal(AD);
                PrincipalSearcher ps = new PrincipalSearcher();
                ps.QueryFilter = ADUser;
                PrincipalSearchResult<Principal> result = ps.FindAll();
                foreach (UserPrincipal CurrentUser in result)
                {
                    PrincipalSearchResult<Principal> userGroups = CurrentUser.GetGroups();
                                     
                using (SqlConnection dataConnection = new SqlConnection("[my sql connection]"))
                {
                    using (SqlCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataCommand.CommandText = "ActiveDirectory.InsertParentRecords";
                        dataCommand.CommandType = CommandType.StoredProcedure;
                        dataCommand.Parameters.AddWithValue("@PackageLogId", Dts.Variables["PackageLogId"].Value.ToString());
                        dataCommand.Parameters.AddWithValue("@cn", "NotFoundYet");
                        
                        if (CurrentUser.GivenName != null)
                        {
                            dataCommand.Parameters.AddWithValue("@givenName", CurrentUser.GivenName.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@givenName", "Empty");
                        }
                        dataCommand.Parameters.AddWithValue("@initials", "NotFoundYet");
                        
                        if (CurrentUser.Surname != null)
                        {
                            dataCommand.Parameters.AddWithValue("@sn", CurrentUser.Surname.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@sn", "Empty");
                        }
                        if (CurrentUser.EmailAddress != null)
                        {
                            dataCommand.Parameters.AddWithValue("@mail", CurrentUser.EmailAddress.ToString());                        
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@mail", "Empty");                        
                        }
                        if (CurrentUser.Name != null)
                        {
                            dataCommand.Parameters.AddWithValue("@Name", CurrentUser.Name.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@Name", "Empty");
                        }
                            
                        if (CurrentUser.MiddleName != null)
                        {
                            dataCommand.Parameters.AddWithValue("@middleName", CurrentUser.MiddleName.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@middleName", "N/A");
                        }
                            
                        dataCommand.Parameters.AddWithValue("@title", "NotFoundYet");
                        if (CurrentUser.EmployeeId != null)
                        {
                            dataCommand.Parameters.AddWithValue("@employeeID", CurrentUser.EmployeeId.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@employeeID", "Empty");    
                        }
                        
                        dataCommand.Parameters.AddWithValue("@employeeNumber", "NotFoundYet");
                        if (CurrentUser.Sid != null)
                        {
                            dataCommand.Parameters.AddWithValue("@objectSid", CurrentUser.Sid.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@objectSid", "Empty");
                        }
                        dataCommand.Parameters.AddWithValue("@userAccountControl", "NotFoundYet" );
                        dataCommand.Parameters.AddWithValue("@whenCreated", "NotFoundYet");
                        if (CurrentUser.DistinguishedName != null)
                        {
                            dataCommand.Parameters.AddWithValue("@distinguishedName", CurrentUser.DistinguishedName.ToString());
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@distinguishedName", "Empty");
                        }
                            
                        dataCommand.Parameters.AddWithValue("@badPasswordTime", "NotFoundYet");  //Issues!!
                        
                        if (CurrentUser.BadLogonCount != null)
                        {
                            dataCommand.Parameters.AddWithValue("@badPwdCount", CurrentUser.BadLogonCount.ToString());
                        }
                        else
	                    {
                            dataCommand.Parameters.AddWithValue("@badPwdCount", "Empty");
                        }
                        dataCommand.Parameters.AddWithValue("@memberof", "Empty");
                        
                        if (CurrentUser.SamAccountName != null)
                        {
                            dataCommand.Parameters.AddWithValue("@samaccountname", CurrentUser.SamAccountName.ToString());
                        }
                        else
	                    {
                            dataCommand.Parameters.AddWithValue("@samaccountname", "Empty");
	                    }
                            
                        if (CurrentUser.Description != null)
                        {
                            dataCommand.Parameters.AddWithValue("@Description", CurrentUser.Description.ToString());
                        }
                        else
	                    {
                            dataCommand.Parameters.AddWithValue("@Description", "Empty");
	                    }
                            
                        dataCommand.Parameters.AddWithValue("@maxPwdAge", "NotFoundYet");   //Issues!!                               
                        if (CurrentUser.LastPasswordSet != null)
                        {
                            dataCommand.Parameters.AddWithValue("@pwdLastSet", CurrentUser.LastPasswordSet.ToString());   //Issues!!
                        }
                        else
	                    {
                            dataCommand.Parameters.AddWithValue("@pwdLastSet", "Empty");   //Issues!!
	                    }
                            
                        if (CurrentUser.AccountLockoutTime != null)
                        {
                            dataCommand.Parameters.AddWithValue("@LockOutTime", CurrentUser.AccountLockoutTime.ToString());     
                        }
                        else
	                    {
                            dataCommand.Parameters.AddWithValue("@LockOutTime", "Empty");     //Issues!!
	                    }
                            
                        if (CurrentUser.Enabled == false)  //Issues!!
                        {
                            dataCommand.Parameters.AddWithValue("@Acctdisabled", '0');
                        }
                        else
                        {
                            dataCommand.Parameters.AddWithValue("@Acctdisabled", '1');
                        }
                        if (CurrentUser.DisplayName != null)
                        {
                            dataCommand.Parameters.AddWithValue("@displayname", CurrentUser.DisplayName.ToString());
                        }
                        else
	                    {
                            dataCommand.Parameters.AddWithValue("@displayname", "Empty");
	                    }
                        dataCommand.Parameters.AddWithValue("@twofactor", "NotFoundYet");     //Calculated from another field     
                        dataCommand.Parameters.Add("@DetailID", SqlDbType.Int);
                        dataCommand.Parameters["@DetailID"].Direction = ParameterDirection.Output;
                        dataConnection.Open();
                        dataCommand.ExecuteScalar();
                        dataConnection.Close();
                        Counter++;
                        DetailID = (int)dataCommand.Parameters["@DetailID"].Value;
                    }  //End of Datacommand
                }  //End of Sql Connection
                using (SqlConnection dataConnection = new SqlConnection("[my sql connection]"))
                {
                    using (SqlCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataConnection.Open();
                        foreach (Principal group in userGroups)
                        {
                            dataCommand.CommandText = "ActiveDirectory.InsertMemberOf";
                            dataCommand.CommandType = CommandType.StoredProcedure;
                            dataCommand.Parameters.Clear();
                            dataCommand.Parameters.AddWithValue("@PackageLogId", Dts.Variables["PackageLogId"].Value.ToString());
                            dataCommand.Parameters.AddWithValue("@DetailID", DetailID);
                            if (group.Description != null)
                            {
                                Debug.WriteLine(group.Description.ToString());
                                dataCommand.Parameters.AddWithValue("@GroupDescription", group.Description.ToString());                                
                            }
                            else
                            {
                                dataCommand.Parameters.AddWithValue("@GroupDescription", "Empty");                                
                            }
                            
                            if (group.Name != null)
                            {
                                Debug.WriteLine(group.Name.ToString());
                                dataCommand.Parameters.AddWithValue("@memberOf", group.Name.ToString());                                
                            }
                            else
                            {
                                dataCommand.Parameters.AddWithValue("@memberOf", "Empty");                                
                            }
                            dataCommand.ExecuteScalar();
                            InnerCounter++;                                                        
                            
                        }  //End of 'For Each Principle'
                    }//End of DataCommand
                }  //End of Data Connection
            
            }   //End of 'For Each User' Loop
