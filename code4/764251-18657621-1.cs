            public List<string[]> UserDetails()
            {
                List<string[]> lsdUserInfoDetails =
                                        new List<string[]>();
                string[] allUserList;
        
                try
                {
                    userDataConnection userContext = new
                                                       userDataConnection();
        
                    var query = (from Info in userContext.UserInfo
                                   select Info).ToList();
        
                    foreach(var userdetails in query)
                       {
                           allUserList = new string[8];
                           allUserList[0] = userdetails.UserName.ToString();
                           allUserList[1] = userdetails.UserCity.ToString();
                           allUserList[2] = userdetails.UserState.ToString();
                           allUserList[3] = userdetails.UserGender.ToString();
                           allUserList[4] = userdetails.UserAge.ToString();
                           allUserList[5] = userdetails.UserDescription.ToString();
        
                           lsdUserInfoDetails.Add(allUserList);  
                       }
        
                   
                }
                catch (Exception es)
                {
                   
                }
        
                return lsdUserInfoDetails;
            }
